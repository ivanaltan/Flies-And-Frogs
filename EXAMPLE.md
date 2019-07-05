# Опис на класата Fly

```
public class Fly
    {
        public int speed;
        public int amplitude;
        public int frequency;
        public bool direction;
        public Point position;
```
^ Полиња со податоци за позицијата и движењето на инсектот.

```
        
        public Point center;
        public int radius;
```
^ Полиња кои помагаат при детектирањето на колизии со јазикот на жаба.

```     
        public Image img1;
        public Image img2;
        public Image img1F;
        public Image img2F;
        public Image img3;
        public Image img3F;
        public Image imgdead;
        public Image imgdeadF;  
```
^ Полиња од слики кои се користат за креирање на анимациите за летот на инсектот.

```
public int img;
```
^ Поле кое го содржи бројот на сликата што последна се прикажала. Се користи за менување на сликата на инсектот.

```
        public bool[] eaten;
```
^ Поле кое означува дали и од кој играч е изеден инсектот.

```
        public int points;
```
^ Поле кое означува колку поени дава инсектот доколку е изеден.

```
        public int frames;
```
^ Поле кое означува колку фрејмови поминале од појавувањето на инсектот. Се користи во формулата за движење во синусоида.

```
        public int deadstate;
```
^ Поле кое означува дали е (0) и во кој дел од состојбата на умирање е инсектот.

```
        public int firsty;
```
^ Поле кое ја чува првата позиција по Y оската кога се појавил инсектот. Се користи во формулата за движење во синусоида.       
        
        
```  

        public Fly(Point position, int speed, int amplitude, int frequency, bool direction)
        {
            this.position = position;
            this.speed = speed;
            this.amplitude = amplitude;
            this.frequency = frequency;
            this.direction = direction;

            center.X = position.X + radius;
            center.Y = position.Y + radius;

            firsty = position.Y;

            deadstate = 0;
            frames = 0;
            img = 1;
            eaten = new bool[4] { false, false, false, false };                   
        }
        
```
^ Конструктор кој зема вредности за полињата кои се однесуваат на движењето и ги иницијализира останатите полиња на 0/false.        
               
``` 


        public virtual void Move()
        {
            if (deadstate != 0)
                return;
```
^ Проверка дали инсектот е во процес на умирање. Во случај да е, тој не се движи.    
               
``` 

            CheckPosition();
            
```
^ Се повикива функцијата за проверка дали инсектот излегол надвор од дозволените рамки.

```
            if (direction)
                position.X += (int)(0.0166 * speed);

            else
                position.X -= (int)(0.0166 * speed);
```
^ Се поместува инсектот по X оската во зависност кон која наскоа е завртен.

```

            position.Y = (int)(Math.Sin(frames * 0.0166 * frequency) * amplitude)+firsty;
```
^ Се поместува инсектот по Y оската со формула за движење во синусоида.

```
            frames++;
```
^ Се зголемува бројот на фрејмови од појавувањето на инсектот.

```

            center.X = position.X + radius;
            center.Y = position.Y + radius;
```
^ Се преместува и центарот на инсектот.

```

            Dissapear();
```
^ Повик на функцијата за проверка дали би требало инсектот да исчезне.

```
        }

        public void MoveStraight()
        {
            if (deadstate != 0)
                return;

            CheckPosition();

            if (direction)
                position.X += (int)(0.0166 * speed);

            else
                position.X -= (int)(0.0166 * speed);

            center.X = position.X + radius;
            center.Y = position.Y + radius;

            frames++;

            Dissapear();
        }
        
```
^ Слична но поедноставена функција за движење во права линија. Се користи ка вилинското коњче.

```


        public void CheckPosition()
        {
            if (position.X <= Adjustments.MinPosXL && direction==false)
            {
                direction = true;
            }
            if (position.X >= Adjustments.MaxPosXR && direction == true)
            {
                direction = false;
            }

        }
```
^ Функција за проверка дали инсектот излегол надвор од дозволените рамки. Доколку излегол му се менува насоката.

```

        public void Draw(Graphics g)
        {
            if (deadstate > 0)
            {
                if (direction)
                        g.DrawImageUnscaled(imgdead, position);

                else    
                        g.DrawImageUnscaled(imgdeadF, position);

                deadstate++;
                return;
            }
```
^ Проверка дали инсектот е во процес на умирање. Доколку е, се црта соодветната слика во зависност од насоката. Исто така се зголемува бројачот на состојбата.

```

            if (direction)
```
^ Проверка за насоката на инсектот. Соодветно се бираат инвертирани или неинвертирани слики.

```
            {
                switch (img)
                {
                    case 1:
                        g.DrawImageUnscaled(img1, position);
                        img++;
                        break;
                    case 2:
                        g.DrawImageUnscaled(img2, position);
                        img++;
                        break;
                    case 3:
                        g.DrawImageUnscaled(img3, position);
                        img++;
                        break;
                    case 4:
                        g.DrawImageUnscaled(img2, position);
                        img=1;
                        break;
                }             
            }
```
^ На секое цртање се менува сликата која се црта со цел да се претстави релативно мазна анимација.

```
            else
            {
                switch (img)
                {
                    case 1:
                        g.DrawImageUnscaled(img1F, position);
                        img++;
                        break;
                    case 2:
                        g.DrawImageUnscaled(img2F, position);
                        img++;
                        break;
                    case 3:
                        g.DrawImageUnscaled(img3F, position);
                        img++;
                        break;
                    case 4:
                        g.DrawImageUnscaled(img2F, position);
                        img = 1;
                        break;
                }
            }
        }

        private void Dissapear()
        {
            if (frames/60 <= Adjustments.FlyLifetime)
                return;

            if ((position.X <= Adjustments.MinPosXL && direction == false) || (position.X >= Adjustments.MaxPosXR && direction == true))
            {
                eaten[0] = true;
            }

        }
```
^ Функција која проверува дали инсектот го пречекорил зададениот лимит за постоење на инсект. Доколку го пречекорил и се наоѓа надвор од видикот на играчите, ќе се означи како изеден со цел класата FliesCollection да го отстрани.

