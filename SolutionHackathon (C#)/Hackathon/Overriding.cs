using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon
    {
    enum SoundMode{ roar, meow }
    
    class Tiger
        {
        public virtual void MakeSound(SoundMode mode)
            {
            if(mode == SoundMode.roar)
                {
                Console.WriteLine("The Tiger can roar");
                }
            else
                {
                Console.WriteLine("Tiger can not roar");
                }
            }
        }

    class Cat : Tiger
        {
        public override void MakeSound(SoundMode mode)
            {
            if(mode == SoundMode.meow)
                {
                Console.WriteLine("The Cat is Meowing");
                }
            else
                {
                Console.WriteLine("Cat not Meowing");
                }
            }
        }
    class Overriding
        {
        static void Main(string[] args)
            {
            Tiger sound = new Tiger();
            sound.MakeSound(SoundMode.roar);

            sound = new Cat();
            sound.MakeSound(SoundMode.roar);
            sound.MakeSound(SoundMode.meow);

            Cat soundnew = new Cat();
            soundnew.MakeSound(SoundMode.roar);
            soundnew.MakeSound(SoundMode.meow);

            }

        }
    }
