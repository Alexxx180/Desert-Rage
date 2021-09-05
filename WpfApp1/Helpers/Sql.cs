using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;

namespace WpfApp1.Helpers
{
    public class Sql
    {
        private const string PublishSource =
            @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ";
        private const string PublishLocation =
            @"\Resources\Database\DesertRageGame.mdf; Integrated Security = True";
        public Sql()
        {
            Con = ParentServerConnection();
            PlayerLogins = new List<string>();
        }
        
        public SqlConnection NewConnection(string path)
        {
            return new SqlConnection(path);
        }
        //[EN] Publishing experimental
        //[RU] Публикация-эксперимент
        public SqlConnection PublishExperimentalConnection()
        {
            return NewConnection(PublishSource +
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                + PublishLocation);
        }
        //[EN] Server connection
        //[RU] Подключение через сервер (ПК создателя)
        public SqlConnection ParentServerConnection()
        {
            string source = "Data Source = SASHA;";
            string catalog = "Initial Catalog=DesertRageGame;";
            string security = "Integrated Security=True";
            return NewConnection(source + catalog + security);
        }
        //[EN] Local connection
        //[RU] Подключение локально
        public SqlConnection LocalConnection()
        {
            return NewConnection(PublishSource +
                Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName
                + PublishLocation);
        }
        //[EN] Publishing local connection
        //[RU] Публикация с локальным подключением
        public SqlConnection PublishLocalConnection()
        {
            return NewConnection(PublishSource +
                Environment.CurrentDirectory + PublishLocation);
        }
        private void NewStoredProcedureBuild(in string ProcedureName)
        {
            Cmd = new SqlCommand(ProcedureName, Con) {
                CommandType = CommandType.StoredProcedure
            };
        }
        private void NewExecuteNonQueryBuild()
        {
            Cmd.Connection.Open();
            _ = Cmd.ExecuteNonQuery();
            Cmd.Connection.Close();
        }
        private List<string> NewSqlDataReaderBuild(List<string> logins)
        {
            Cmd.Connection.Open();
            DataReader = Cmd.ExecuteReader();
            if (DataReader.HasRows)
                while (DataReader.Read())
                    logins.Add(DataReader.GetValue(0).ToString());
            Cmd.Connection.Close();
            return logins;
        }
        private string NewSqlDataReaderBuild(string Selected, in byte Column)
        {
            Cmd.Connection.Open();
            DataReader = Cmd.ExecuteReader();
            if (DataReader.HasRows)
                while (DataReader.Read())
                    Selected = DataReader.GetValue(Column).ToString();
            Cmd.Connection.Close();
            return Selected;
        }
        private string NewSqlDataReaderBuild(in byte Column)
        {
            string uo = "0";
            Cmd.Connection.Open();
            DataReader = Cmd.ExecuteReader();
            if (DataReader.HasRows)
                while (DataReader.Read())
                    uo = DataReader.GetValue(Column).ToString();
            Cmd.Connection.Close();
            return uo;
        }
        private object[] NewSqlDataReaderBuild(object[] Values, in byte StartValue, in byte EndValue)
        {
            Cmd.Connection.Open();
            DataReader = Cmd.ExecuteReader();
            if (DataReader.HasRows)
                while (DataReader.Read())
                    for (byte i = StartValue; i < EndValue; i++)
                        Values[i - StartValue] = DataReader.GetValue(i);
            Cmd.Connection.Close();
            return Values;
        }
        private byte[] NewSqlDataReaderBuild(byte[] Values, in byte StartValue, in byte EndValue)
        {
            Cmd.Connection.Open();
            DataReader = Cmd.ExecuteReader();
            if (DataReader.HasRows)
                while (DataReader.Read())
                    for (byte i = StartValue; i < EndValue; i++)
                        Values[i - StartValue] = Convert.ToByte(DataReader.GetValue(i));
            Cmd.Connection.Close();
            return Values;
        }

        private void AddProcedureParameter(in string ParamName, in object newParam)
        {
            Dictionary<string, SqlDbType> types = new Dictionary<string, SqlDbType>()
            {
                { "Boolean", SqlDbType.Bit }, { "UInt16", SqlDbType.SmallInt },
                { "Byte", SqlDbType.TinyInt }, { "String", SqlDbType.VarChar }
            };
            Cmd.Parameters.Add(ParamName, types[newParam.GetType().Name]).Value = newParam;
        }
        private void AddProcedureParametersX(in string[] paramNames, in object[] newParams)
        {
            for (byte i = 0; i < paramNames.Length; i++)
                AddProcedureParameter(paramNames[i], newParams[i]);
        }
        private void CheckIfPlayersListIsNotNull()
        {
            if (PlayerLogins.Count > 0)
                PlayerLogins.Clear();
        }
        public void DeselectAllPlayers()
        {
            NewStoredProcedureBuild("DeselectPlayers");
            NewExecuteNonQueryBuild();
            Cmd.Parameters.Clear();
        }
        public void NewPlayer(in string NewPlayerLogin)
        {
            NewStoredProcedureBuild("AddNewProfile");
            AddProcedureParameter("@LOGIN", NewPlayerLogin);
            NewExecuteNonQueryBuild();
            Cmd.Parameters.Clear();
        }
        public void DeletePlayer(in string ExistingPlayerLogin)
        {
            NewStoredProcedureBuild("DeleteProfile");
            AddProcedureParameter("@LOGIN", ExistingPlayerLogin);
            NewExecuteNonQueryBuild();
            Cmd.Parameters.Clear();
        }
        public void CheckAllRecordedPlayers()
        {
            CheckIfPlayersListIsNotNull();
            NewStoredProcedureBuild("CheckLogin");
            PlayerLogins = NewSqlDataReaderBuild(new List<string>());
            Cmd.Parameters.Clear();
        }
        public string GetCurrentPlayer()
        {
            NewStoredProcedureBuild("CheckSelected");
            CurrentLogin = PlayerLogins.Count > 0 ?
                (NewSqlDataReaderBuild("????", 0) == "????" ? PlayerLogins[0]
                : NewSqlDataReaderBuild("????", 0)) : "????";
            Cmd.Parameters.Clear();
            return CurrentLogin;
        }
        public object[] CheckPlayerBag(in string PlayerLogin, in object[] Items)
        {
            NewStoredProcedureBuild("CheckBAG");
            AddProcedureParameter("@LOGIN", PlayerLogin);
            return NewSqlDataReaderBuild(Items, 2, 11);
        }
        public byte[] CheckPlayerEquip(in string PlayerLogin, in byte[] Equip)
        {
            NewStoredProcedureBuild("CheckEquip");
            AddProcedureParameter("@LOGIN", PlayerLogin);
            return NewSqlDataReaderBuild(Equip, 2, 10);
        }
        public object[] GetPlayerRecord(in string PlayerLogin, in object[] RecordValues)
        {
            NewStoredProcedureBuild("CheckPlayer");
            AddProcedureParameter("@LOGIN", PlayerLogin);
            return NewSqlDataReaderBuild(RecordValues, 1, 8);
        }
        public object[] GetPlayerStats(in string PlayerLogin, in object[] Params)
        {
            NewStoredProcedureBuild("CheckParams");
            AddProcedureParameter("@LOGIN", PlayerLogin);
            return NewSqlDataReaderBuild(Params, 1, 7);
        }
        public byte[] GetPlayerSettings(in string PlayerLogin, in byte[] Settings)
        {
            NewStoredProcedureBuild("CheckSettings");
            AddProcedureParameter("@LOGIN", PlayerLogin);
            return NewSqlDataReaderBuild(Settings, 2, 8);
        }
        public void SavePlayerBag(in string[] Parameters, in object[] Items)
        {
            NewStoredProcedureBuild("GetNewItemsBag");
            AddProcedureParametersX(Parameters, Items);
            NewExecuteNonQueryBuild();
        }
        public void SavePlayerEquip(in string[] Parameters, in object[] Equipment)
        {
            NewStoredProcedureBuild("GetNewEquip");
            AddProcedureParametersX(Parameters, Equipment);
            NewExecuteNonQueryBuild();
        }
        public void SavePlayerStats(in string[] Parameters, in object[] Stats)
        {
            NewStoredProcedureBuild("GetNewParams");
            AddProcedureParametersX(Parameters, Stats);
            NewExecuteNonQueryBuild();
        }
        public void SavePlayerSettings(in string[] Parameters, in object[] Settings)
        {
            NewStoredProcedureBuild("GetNewSettings");
            AddProcedureParametersX(Parameters, Settings);
            NewExecuteNonQueryBuild();
        }
        public void NewGameStart(in string PlayerLogin)
        {
            NewStoredProcedureBuild("NewGameStart");
            AddProcedureParameter("@LOGIN", PlayerLogin);
            NewExecuteNonQueryBuild();
        }
        public bool CheckIfPlayerCanContinue()
        {
            NewStoredProcedureBuild("CheckPlayer");
            AddProcedureParameter("@LOGIN", CurrentLogin);
            return Convert.ToByte(NewSqlDataReaderBuild("1", 2)) > 0;
        }
        public string CheckTask()
        {
            NewStoredProcedureBuild("CheckTask");
            AddProcedureParameter("@LOGIN", CurrentLogin);
            return NewSqlDataReaderBuild(0);
        }
        public SqlCommand Cmd { get; set; }
        public SqlDataReader DataReader { get; set; }
        public SqlConnection Con { get; set; }
        public List<string> PlayerLogins { get; set; }
        public string CurrentLogin { get; set; }
    }
}
