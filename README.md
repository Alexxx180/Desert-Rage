# Tatarintsev_8901
Основы работы с репозиторием "Alexxx180/Tatarintsev_8901", 
краткое руководство.

Условные знаки:
- [?] - Озадачивание, вопросы для разбора.
- |X| - Вы находитесь на... .
- (i)  - Материал для освоения.
- /!\  - Важная информация.
- @ - Представим... .

1 Нажмите и перейдите по ссылке:
https://github.com/Alexxx180/Tatarintsev_8901/tree/master

-==========================================================================================-

2 Что такое git и почему из веток там тоже поделки делают?

|X| Репозиторий Alexxx180/Tatarintsev_8901, ветвь master .

[?] Итак, вы видите перед собой сайт git, не сильно интуитивно 
понятный, да ещё и на английском языке.

2.1 Заголовок сайта

(i) В основном он используется для следующих целей:
- Регистрация/Авторизация пользователей (входить вам не 
нужно, весь функционал доступен, т.к. репозиторий 
публичный)
- Магазин (используется для бизнеса, тоже не нужен)
- Исследование (для поиска других репозиториев и прочего)
- и т.д.

2.2 Строка - путеводитель

Нас интересует строка что расположена после гида по git - 
строка пути расположения удалённого git-репозитория.

(i) Это путь по которому пользователь может переходить к 
репозиторию в дальнейшем, набрав в строке поиска:
          github.com/[Адрес репозитория]

/!\ Так, полный путь выглядит подобным образом:
  github.com/[Адрес репозитория][/tree/[Ветвь]]

2.3 Как вы могли заметить сам Git предполагает древовидную 
иерархию, наблюдаемую во многих системах.

/!\ Здесь мы можем увидеть абстрактные ветви, созданные 
пользователем, их название может быть любым, но как 
правило принято выделять следующие ветви:

 - main - главная ветвь, на которой происходят действия по 
представлению продукта.
 - develop - ветвь разработки, в которую сливается основная 
ветвь разрабатываемого продукта и побочные ветви
 - master - основная ветвь, на которой происходит основной 
процесс разработки, такой как внедрение функционала 
изменение основного кода
 - features - ветвь фич, по умолчанию может отсутствовать
 - bugfixes - ветвь исправления багов, по умолчанию может 
отсутствовать
  и т.п.

Если представить схематически, то они выглядят следующим
образом:

    |==================main================|
    |++++++++++++++++++||||++++++++++++++++|
    |++++++++++++++++develop+++++++++++++++|
    |+++++++++++++////+||||+\\\\+++++++++++|
    |++++++++++++////++||||++\\\\++++++++++|
    |+++++++++++////+++||||+++\\\\+++++++++|
    |++++++++++////++++||||++++\\\\++++++++|
    |+++++++features++master+bugfixes++++++|
    |+++++[d 1.007]++[d 1.0]+[d 1.007]+++++|
    |======================================|

/!\ Внимание, использование ветвей предполагает наличие 
разделов, отвечающих за своё место в разработке 
приложения.
    Как правило определённое количество ветвей служит для 
распараллеливания задач в команде и соответствующего 
распределения ролей.

(i) Так, например, я выступаю в роли FullStack-разработчика и 
отвечаю за абсолютно все процессы разработки от создания 
макетов и прорисовки интерфейсов вплоть до написания и 
отладки кода, взаимодействия с базой данных.
    В этом случае абсолютно все рабочие файлы находятся у 
меня в локальном репозитории на одном компьютере и для 
записи прогресса мне достаточно лишь одной ветви master.

(i) На будущее:
    Репозиторий - пространство для расположения 
представлений данных.

3 Файлы.

3.1 Место в репозитории
    Основное пространство работы представлено в виде 
прямоуголника скругленного по краям. 

(i) В левом верхнем углу вы можете увидеть иконку и логин 
создателя репозитория. Также здесь вы можете увидеть 
версию проекта, о них позже.

(i) Сейчас вы находитесь в ветви master, если по какой-то 
причине вы не видите папки и файлы указанные ниже, то 
скорее всего вы находитесь на другой ветви. Для смены 
ветвей используйте combobox над рабочим пространством.
  
  Всё довольно просто: файлы находятся в папках, которые 
обозначены знакомыми видами иконок.

/!\ В данном репозитории вы видите файл - файл решения для 
Microsoft Visual Studio 2019 (Уже 2021 год...), с 
предустановленными пакетами .Net Core, используемая 
технология: WPF.

    Здесь же расположена автоматически сгенерированная 
студией папка (.vs/WpfApp1), отвечающая за инициализацию и 
запись настроек приложения. Удалять её НИ В КОЕМ случае 
НЕЛЬЗЯ.
    И основная папка с проектом и его ресурсами, с которой мы и 
будем работать - WpfApp1

/!\ Всё это помимо основного файла руководства, который вы 
сейчас читаете.

3.2 Первое взаимодействие

  Попробуйте открыть папку WpfApp1 щелчком мыши.
Здесь вы увидите ОГРОМНОЕ количество папок , каждая из 
которых содержит наборы статических изображений.

>"Где деньги, Лебовски?"
(из к/ф "Большой Лебовски")

|X| Репозиторий Alexxx180/Tatarintsev_8901, ветвь master, 
папка WpfApp1

  Часть из этих изображений используется для создания 
покадровой анимации внутри программы.

[?] Зачем? Ну так скажем файлы которые спокойно на 
достойном уровне поддерживаются практически всеми 
игровыми двигателями далеко не всегда поддерживаются 
обычными шаблонами окон.

     Поэтому приходится использовать незамысловатые 
решения (по типу виртуальных машин, только глубже) для 
имитации грамотной работы с ними (особенно это надоедает, 
когда она неправильно видит ресурс).

    Сразу прошу извинить за творческий беспорядок - 
прегрешность старых версий. Вместе с этим, на примере
прошлых файлов, вы можете посмотреть как работает 
одна из особенностей системы контроля версий. 

(i) Как вы могли заметить - у каждого файла/папки стоит 
непонятное описание. Каждое такое описание обозначает 
версию файла. Когда он появился, был отредактирован, и т.д.

/!\ Далее мы перейдём к самому важному разделу - системе 
контроля версий. Это самый полезный инструмент, который вы 
только видели. 

-==========================================================================================-

4. Система контроля версий

4.1 Немного поразмышляем

(i) Вспомним ORACLE - он поможет разобраться (commit)

@ Ситуация. Вы закончили работу, сохранили её. Всё в 
порядке. Компьютер дал сбой. После восстановления вам не 
удалось спасти файл, а вы не успели перекинуть его в 
удалённый репозиторий. Как же много работы придётся теперь 
делать.

    С постоянно обновляемой вами (можно настроить VS и 
подобный ему IDE для автообновления репозиториев и тогда 
точно будет ракета) системой версией, такого кошмара уже не 
произойдёт.

@ А что если git... Вы потеряли файл. Да, вы не сможете его 
восстановить, но у вас есть все прошлые версии этого файла и 
вам не нужно начинать всё заново.

    Достаточно восстановиться с последней. Или при сдаче 
работ, кто-то попросил версию альфа и вы со спокойной душей 
перешли куда нужно и отдали её без хлопот.

/!\ Моя цель: познакомить с основными узлами но не заставлять 
вас работать здесь, вся работа по сохранности версий на мне - 
вам же достаётся удовольствие (даже большее чем просто 
удалёнка) открывать их как подарки и смотреть что внутри.

/!\ Помните, это не сложно (- v -). Особенно с GUI.

4.2 Самое интересное впереди

Много разговоров? Cейчас всё увидите.
Щёлкните по History с иконкой часиков в правом верхнем углу.

|X| Система версий Alexxx180/Tatarintsev_8901/tree/master

(i) Перед собой вы видите все версии, от самой последней 
(самая верхняя), до самой первой (самой нижней, именно её я 
защищал в первый раз).

/!\ При щелчке на любую из версий вы попадаете в место, где 
происходят записи push, произведённых мной с локального ПК 
под моей учётной записью с помощью GitBash. Для примера 
рассмотрим самую первую версию, DesertRage_demo_1.0.

|X| Версия DesertRage_demo_1.0, комната request-ов

    Однако понимаем, что делать здесь нам нечего, это комната 
для персонала чтобы смотреть какой я молодец... КХМ, чтобы 
наблюдать изменения полученные от локальных репозиториев. 

    Далее щёлкаем по Browse Files и попадаем в зазеркалье...

4.3 Назад к backup'ам
>"Она работает, Марти!" (из к/ф "Back To The Future (Назад в 
будущее)")

|X| Версия DesertRage_demo_1.0, файлы

  Вот мы и в далёком прошлом... 25 дней тому назад. День 
когда я сделал первый коммит. Чудо? Нет, торжество 
абстракции. Теперь мы можем таким же образом по аналогии 
посмотреть что было до того как.

/!\ Помимо всего прочего, вы можете скачать весь репозиторий 
(где сейчас находимся), так и отдельную папку, для этого 
нужно в неё перейти. 
- Нажимаем на Code (зелёненькая кнопка-combobox)->Скачать 
ZIP.
- Ждём загрузку и ву-аля, весь код моей машины у вас.

(i) Самое главное: всевозможные инструменты git, такие как 
github, gitlab и пр. позволяют предварительно показывать 
самые разнообразные форматы файлов, такие как png, jpg - 
изображения, текстовые файлы, а может даже фрагменты 
базы данных.

>"Думали, я вас не переиграю?..." - (Очень хорошая цитата, от 
одного не менее интересного уставшего человека. 
https://www.youtube.com/watch?v=MgI5JUiN-GQ)

(i) А и чуть не забыл, как только вы перейдёте на эту версию
путь назад будет, но не такой как раньше. Как только вы
перешли по коммиту, по истории он будет отображать только те
коммиты, которые произошли до него, т.е. тот самый единственный.
Есть несколько путей, самый проверенный но грубый идти туда же,
откуда пришли, просто нажимать назад (<-) (Git воспримет это
вполне нормально, мне ничего не будет), но есть для таких как я:
просто жмакаем по невнятным символам у знакомого checkbox'а,
и выбираем master. Вот мы и дома.

/!\ Из-за такого лихого телепорта само время символы у ветки
исказились - они стали уникальным кодом коммита, по которому
можно будет вернуться.

    Ну что же в целом краткий экскурс подошёл к концу. Дальше 
идёт классификация файлов, что к чему.

5 Файлы, их разновидности

/!\ Если не знаете некоторых терминов, что такое режим боя, 
карта и пр. рекомендую перечитать мою курсовую - оригинал 
есть.

5.1 Png-изображения

    В виде .png представлены изображения которые должны 
иметь свойство прозрачности, а именно:
- Интерактивные модели на карте, такие, как: персонаж, 
артефакт, ключи и пр.
- Модели и анимация в бою (смена изображений героя и 
врагов).
- Декорации (для кнопок и прочего)

5.2 Jpg-изображения

(i) Это достаточно хороший, серьёзный формат, я предпочёл 
его Bitmap - т.к. весит он поменьше, но качество при сжатии 
теряется не сильно + потери можно контролировать.

    В виде .jpg представлены достаточно большие изображения, 
не требующие сохранения прозрачности, например:
- Карта
- Поле боя
- Начальный экран

5.3 Файл с кодом XAML (XML)

(i) Тот самый, но под другим ракурсом. В WPF он используется 
как описание интерфейса приложения - это НЕВЕРОЯТНО 
удобно, особенно когда вас двое, один пишет код как 
паровоз, а другой как пароход - на воду рельсы 
прокладывает. При открытии в VS 2019 можно работать с ним 
как с конструктором.

Представлен в единственном экземпляре:
-MainWindow.xaml

(i) Однако, вы можете найти файл самого приложения, через 
который оно и инициализируется, его трогать не стоит:
-App.xaml

5.4 Файл с кодом .cs (C#)

  Здесь представлен файл с кодом главного и единственного 
окна.
  Да так уж повелось что некоторые жанры игры намного 
лучше выглядят, когда у них только одно окно, они растянуты 
на полный экран, дабы ничего не отвлекало и чтобы десять раз 
не прерывать игрока бесконечными диалоговыми, всё сделано 
внутри самой игры. 
  Представлен в виде единственного экземпляра:
-MainWindow.xaml.cs

(i) Однако, вы можете найти файл самого приложения, через 
который оно и инициализируется, его трогать не стоит:
-App.xaml.cs

5.5 Файлы .gif

/!\ Это остаточные файлы, они могут присутствовать в 
некоторых версиях, в будущем их планирую убрать.

(i) Это очень жуткая попытка реализовать в WPF с помощью 
MediaElement анимацию - в те времена тестов программа 
постоянно вылетала, давала сбои как только она появлялась, 
выставляя меня у тестеров полным неучем.
    
    В принципе можете открыть и посмотреть некоторые - они 
достаточно забавны) И представляют раннюю версию уже 
другого более безопасного и практически безотказного 
функционала.

5.6 Файлы .avi

/!\ Это остаточные файлы, они могут присутствовать в 
некоторых версиях, в будущем их планирую убрать.
    
    Пожалуй, это единственные файлы, которые вообще способны 
корректно отображаться в MediaElement практически любого 
размера и любой длительности.
    К сожалению их основной недостаток - колоссальная трата 
памяти, а результата, как говорится 0.
    Я убрал их из проекта, т.к. это экономически не выгодно.

5.7 Файлы .mp4

    Здесь наблюдается достаточно интересная взаимосвязь:
чем меньше такой файл, чем чаще его используют и чем 
меньше его длительность тем выше % что будет сбой. Именно 
поэтому мне пришлось распрощаться в нынешней (и 
нескольких предыдущих) версии игры с анимацией в виде 
проигрывания  mp4 - хотя по сравнению с остальными 
форматами он держится достойно и в среднем его хватит на то 
чтобы вы дошли и одолели фараона.

    Однако полностью его смещать я не стал, т.к. он крайне
удобен в отдельных случаях, а именно полноэкранный режим,
где он до сих пор служит для создания cut-сцен. Там этот
процент если и не 0, то где-то 1*E^-318.

5.8 Файлы .mp3

    Несмотря на предыдущие неудачи, данный формат показал 
себя крайне достойно, очень сильно меня выручив, когда 
оказалось что та музыка, которую я так долго подбирал не 
проигрывалась на чужих ПК. Тогда я использовал свободный 
формат .ogg - чуть менее сжатый, превосходно работающий на 
игровых двигателях (для них возможно и используется, но и не 
только).
    Можете послушать некоторые - музыку я брал что надо,
насчёт прав тоже всё полный порядок, нигде не задейство-
вана, либо автор дал согласие свободно использовать, либо
и то и другое - всё согласованно.

-==========================================================================================-

Подводим итоги

   На этом всё, благодарю за чтение или прослушивание данного 
материала.

>"Суть игр - чтобы сделать довольным как можно большее 
количество людей, научить чему-то новому, высокому. При чём 
сделать это самыми не замысловатыми, но очень 
увлекательными способами." (Линзы Геймдизайна, неизвестный)

>"Создатель игр по-своему страдает как поэт над книгой, но 
точно также каждый раз получает счастье, когда кто-то 
проявляет к нему внимание." (Линзы Геймдизайна, неизвестный)
