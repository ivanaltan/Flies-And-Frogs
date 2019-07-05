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
^ Поле кое означува колку фрејмови поминале од појавувањето на инсектот. Се користи во формулата за движење во парабола.

```
        public int deadstate;
```
^ Поле кое означува дали е (0) и во кој дел од состојбата на умирање е инсектот.

```
        public int firsty;
```
^ Поле кое ја чува првата позиција по Y оската кога се појавил инсектот. Се користи во формулата за движење во парабола.       
        
        
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


        public virtual void Move()
        {
            if (deadstate != 0)
                return;

            CheckPosition();

            if (direction)
                position.X += (int)(0.0166 * speed);

            else
                position.X -= (int)(0.0166 * speed);

            position.Y = (int)(Math.Sin(frames * 0.0166 * frequency) * amplitude)+firsty;


            frames++;

            center.X = position.X + radius;
            center.Y = position.Y + radius;

            Dissapear();
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


            if (direction)
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
