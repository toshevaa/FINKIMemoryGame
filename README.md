## 1. Опис на Апликацијата
Апликацијата FINKI Memory Game е наменета за забава и ментална гимнастика преку игра на меморија. Корисниците имаат задача да пронајдат парови идентични карти со слики од различни програмски јазици, рамки, прелистувачи и оперативни системи. 
Играта се развива со нивоа, при што секое ново ниво динамички додава нови карти и ја зголемува тежината.

## 2. Упатство за користење
 ### 2.1. Почетен Екран за Подготовка
Пред да започне играта, корисникот има 5 секунди на располагање за подготовка.
Во овој период, на екранот се прикажува порака за подготовка на корисникот за наредното ниво.

### 2.2. Преглед на Картичките
Откако ќе поминат 5 секунди, картичките стануваат видливи за корисникот.
Корисникот има само 3 секунди да ги погледне картичките пред да започне со спарување.

### 2.3. Спарување на Картички
Корисникот треба да кликне на две картички со цел да ги спари.
Ако корисникот успешно спари две идентични картички, му се доделуваат 15 поени и му се додаваат 2 секунди на времето.
Ако корисникот не успее да ги спари идентичните картички, му се одземаат 5 поени од неговиот вкупен резултат.

![memory_game_screenshot](https://github.com/toshevaa/FINKIMemoryGame/assets/128093561/665b96c2-c119-4b5c-ae20-475a7651aade)

## 3. Функционалности
- Класата MemoryGameForm: Оваа класа ги содржи сите UI компоненти и логиката за играта.
- Динамичко генерирање на карти: Картите се генерираат динамички со секое поминато ниво, зголемувајќи ја тежината.
- Центрирање на UI компоненти: UI компонентите, како PictureBox контролите, се центрирани и се прикажуваат целосно на екранот, без разлика на бројот на карти.
- Функционалност за вртење на карти: Карти кои се избираат од корисникот се превртуваат за да ја прикажат сликата.
- Форма за крај на играта: Форма која се појавува кога времето ќе истече.

## 4. Опис на методот InitializeGame

  
         private void InitializeGame(int rows = 2, int cols = 3)
         {
  
         if (bgMusic.playState != WMPPlayState.wmppsPlaying)
         {
             bgMusic.URL = "quizCountdown.mp3";
             bgMusic.settings.setMode("loop", true);
             bgMusic.controls.play();
         }

         cardFlip.URL = "cardFlip.mp3";

         this.currentRows = rows;
         this.currentCols = cols;

         AdjustIconSizeAndPosition(rows, cols);
         generateShuffledTags();

         int tagIndex = 0;
         int totalWidth = currentCols * (iconSize + 10) - 10;
         int totalHeight = currentRows * (iconSize + 10) - 10;
         int startX = (this.ClientSize.Width - totalWidth) / 2;
         int startY = splitContainer1.Bottom + ((this.ClientSize.Height - splitContainer1.Height - totalHeight) / 2);

         for (int i = 0; i < this.currentRows; i++)
         {
             for (int j = 0; j < this.currentCols; j++)
             {
                 PictureBox p = new PictureBox();
                 ((ISupportInitialize)(p)).BeginInit();
                 p.Tag = tags[tagIndex++];
                 Bitmap bmp = (Bitmap)Properties.Resources.ResourceManager.GetObject(p.Tag.ToString());
                 p.Image = bmp;
                 p.BorderStyle = BorderStyle.FixedSingle;
                 p.Location = new Point(startX + j * (iconSize + 10), startY + i * (iconSize + 10));
                 p.Name = "pictureBox" + i.ToString() + j.ToString();
                 p.Size = new Size(iconSize, iconSize);
                 p.SizeMode = PictureBoxSizeMode.StretchImage;
                 p.TabStop = false;
                 p.BackColor = Color.Transparent;
                 p.Parent = this;
     
                 p.Click += new EventHandler((sender, e) => this.cardReveal(sender, e, p));
                 this.pictures.Add(p);
                 this.Controls.Add(p);
                 ((ISupportInitialize)(p)).EndInit();
             }
         }
         previewCardsTimer.Start();
         this.ResumeLayout();
       }


### 4.1. Подесување на Позадинска Музика и Звучен Ефект за ревртувањето на артичките
  Се проверува дали позадинската музика (bgMusic) не е веќе во тек (WMPPlayState.wmppsPlaying).
  Ако не е во тек, се поставува URL на музичката датотека (quizCountdown.mp3), се поставува на режим на повторување и се стартува пуштањето на музиката. Исто така се поставува звучен ефект за превртувањето на картичките.

### 4.2. Поставување на Редици и Колони
  Се поставува бројот на редици (currentRows) и колони (currentCols) за играта во зависност од проследените параметри (rows и cols). Почетните вредности се 2 редици и 3 колони ако немаат вредности за rows и cols, но со секое зголемување на левелот тие се зголемуваат за 1.
  
  ### 4.3. Прилагодување на Икони и Позиции
  Повик до функцијата AdjustIconSizeAndPosition(rows, cols) за да се прилагоди големината и позицијата на иконите во зависност од бројот на редици и колони.
  
  ### 4.4. Генерирање на Рандомизирани Тагови:
  Повик до функцијата generateShuffledTags() за да се генерираат и рандомизираат таговите кои ќе се користат за иконите во играта.

### 4.5. Иницијализација на PictureBox Елементи:
  Се користи вгнезден for циклус за да се креираат и додадат PictureBox елементи во играта.
  За секоја комбинација на редица и колона, се креира нов PictureBox (p).
  На новокреираниот PictureBox му се доделува таг од генерираните рандом тагови за иконите.
  Сликата на PictureBox се поставува соодветно на вчитаната слика од ресурсите (Properties.Resources.ResourceManager.GetObject(p.Tag.ToString())).
  Поставување на различни својства како стил на border, локација, име, големина, начин на прикажување, боја на позадина и припаѓање на родителскиот контрол (this формата).

### 4.6. Додавање на EventHandler (Click на PictureBox) за функцијата cardReveal.
  Додавање на креираниот PictureBox во колекцијата pictures и во контролите на формата (this.Controls.Add(p)).

### 4.7. Почеток на Тајмер за Преглед на Картички:
  Стартување на тајмер (previewCardsTimer.Start()) за да започне тајмерот за преглед на картичките.

## 5. Користени методи во MemoryMatchingForm.cs
**AdjustIconSizeAndPosition(int rows, int cols)** - Ги прилагодува големината и позицијата на иконите врз основа на бројот на редици и колони.

**generateShuffledTags()** - Генерира случајно измешани тагови за картичките што се користат во играта.

**MemoryGameForm()** - Конструктор на формата, поставува почетни параметри и го започнува првото ниво на играта.

**startNextLevel()** - Почнува следното ниво од играта, прикажувајќи соодветна порака и започнува нов тајмер за следното ниво.

**cardReveal(object sender, EventArgs e, PictureBox p)** - Открива картички при клик на нив и проверува дали две отворени картички се исти.

**goToNextLevel()** - Префрлање на играта на следното ниво и подготвува нови картички.

**gameOver()** - Играта завршува, прикажува крајна порака и резултати.

**increaseCounterBy(int count)** - Зголемување на бројачот за време за дадениот број на секунди.

**incorrectPairTimer_Tick(object sender, EventArgs e)**  - Тајмер за прикажување на две неуспешно спарени картички, пред нивно затворање.

**gameTimer_Tick(object sender, EventArgs e)** - Тајмер за играта.

**previewCardsTimer_Tick(object sender, EventArgs e)**  - Тајмер за преглед на картичките пред да започне играта, потоа започнува главниот тајмер на играта.

**nextLevelCountdownTimer_Tick(object sender, EventArgs e)**  - Тајмер за броење на време пред следното ниво на играта, прикажување на пораки и започнување на новото ниво.

**hideNextLevelText()** - Сокривање на пораките и време за следното ниво на играта по истекувањето на времето за подготовка.

**showNextLevelText()**  - Прикажување на пораките и времето за приготовка за следното ниво на играта.

![image](https://github.com/toshevaa/FINKIMemoryGame/assets/128093561/0c40dc3f-e11b-436a-8174-5c7be451da50)

 
 


  



