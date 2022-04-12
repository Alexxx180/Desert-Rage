using System;
using System.IO;
using System.Text.Json;
using System.Windows;
using DesertRage.ViewModel;
using Microsoft.Win32;
using Serilog;

namespace DesertRage.Writers
{
    public static class Processors
    {
        public static string
            DataDirectory => Environment.CurrentDirectory +
            @"\Resources\Data\";
        private static string ProfileDirectory => DataDirectory + @"Profiles\";

        static Processors()
        {
            Log.Debug(
                "Data directory set as: "
                + DataDirectory
                );
        }

        #region Messages Members
        private static void SaveMessage(string exception)
        {
            string noLoad = "Не удалось сохранить файл.";
            string message = "\nУбедитесь, что посторонние процессы не мешают операции.\n";
            string advice = "Свяжитесь с администратором насчет установления причины проблемы.\nПолное сообщение:\n";
            _ = MessageBox.Show(noLoad + message + advice + exception);
        }

        internal static void LoadMessage(string exception)
        {
            string noLoad = "Сбой загрузки.";
            string message = "\nУбедитесь, что файлы не повреждены или отсутствуют в целевой директории.\n";
            string advice = "Свяжитесь с администратором насчет установления причины проблемы.\nПолное сообщение:\n";
            _ = MessageBox.Show(noLoad + message + advice + exception);
        }

        internal static void WriteMessage(string exception)
        {
            string message = "Файл открыт в другой " +
                    "программе или используется другим " +
                    "процессом. Дальнейшая запись в файл" +
                    " невозможна.\nПолное сообщение:\n";
            _ = MessageBox.Show(message + exception);
        }
        #endregion

        #region Dialogs Members
        public static OpenFileDialog
            CallManager(string filter, string fileName)
        {
            return new OpenFileDialog
            {
                FileName = fileName,
                Filter = filter
            };
        }

        public static SaveFileDialog
            CallWriter(string filter, string fileName)
        {
            return new SaveFileDialog
            {
                FileName = fileName,
                Filter = filter
            };
        }
        #endregion

        internal static void TruncateFile(string fileName)
        {
            Log.Information("Truncating file: " + fileName);
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

        public static void Save(string path, byte[] bytes)
        {
            Log.Information("Saving data... to: " + path);
            try
            {
                File.WriteAllBytes(path, bytes);
            }
            catch (IOException exception)
            {
                Log.Error("Save problem: " +
                    exception.Message);
                SaveMessage(exception.Message);
            }
        }

        public static T ReadJson<T>(string path)
        {
            Log.Information("Reading user data from: " + path);
            T deserilizeable = default;
            try
            {
                byte[] fileBytes = File.ReadAllBytes(path);
                Utf8JsonReader utf8Reader = new Utf8JsonReader(fileBytes);
                deserilizeable = JsonSerializer.Deserialize<T>(ref utf8Reader);
            }
            catch (JsonException exception)
            {
                Log.Error("Reading user data Json problem: " +
                    exception.Message);
                LoadMessage(exception.Message);
            }
            catch (ArgumentException exception)
            {
                Log.Error("Argument is invalid: " +
                    exception.Message);
                LoadMessage(exception.Message);
            }
            catch (IOException exception)
            {
                Log.Error("I|O blocked by another process: " +
                    exception.Message);
                LoadMessage(exception.Message);
            }
            return deserilizeable;
        }

        private static void ProcessJsonAny<T>(string path, T serilizeable)
        {
            try
            {
                TruncateFile(path);
                byte[] jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(serilizeable);
                File.WriteAllBytes(path, jsonUtf8Bytes);
            }
            catch (IOException exception)
            {
                Log.Error("I|O blocked can't process: " +
                    exception.Message);
                LoadMessage(exception.Message);
            }
        }

        #region SaveLoad Members
        internal static UserProfile LoadProfile(string name)
        {
            Log.Debug("Loading runtime: " + ProfileDirectory + name);
            return !File.Exists(ProfileDirectory + name) ? null :
                ReadJson<UserProfile>(ProfileDirectory + name);
        }

        internal static void SaveProfile(string name, UserProfile data)
        {
            ProcessJsonAny(ProfileDirectory + name, data);
        }
        #endregion
    }
}