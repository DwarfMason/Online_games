using System;

namespace WebApplication1.Game.BaseClasses.Equipment
{

    public abstract class IEquipmentGenerator
    {
        public abstract CEquipmentInventory Generate();
    }

    public class CEquipmentGenerator<T>:IEquipmentGenerator where T:CEquipmentInventory,new()
    {
        public class NormalRandom : Random
        {
            private double deviation,expectation;
            
            public NormalRandom(double d,double e)
            {
                deviation = d;
                expectation = e;
            }
            // сохранённое предыдущее значение
            double prevSample = double.NaN;
            
            protected override double Sample()
            {
                double out_;
                // есть предыдущее значение? возвращаем его
                if (!double.IsNaN(prevSample))
                {
                    double result = prevSample;
                    prevSample = double.NaN;
                    out_ = result* deviation + expectation;
                    if ((out_ > 10)||(out_ < 0))
                    {
                        out_ = NextDouble();
                    }
                    return out_;
                }

                // нет? вычисляем следующие два
                // Marsaglia polar method из википедии
                double u, v, s;
                do
                {
                    u = 2 * base.Sample() - 1;
                    v = 2 * base.Sample() - 1; // [-1, 1)
                    s = u * u + v * v;
                }
                while (u <= -1 || v <= -1 || s >= 1 || s == 0);
                double r = Math.Sqrt(-2 * Math.Log(s) / s);

                prevSample = r * v;
                out_ = r * u * deviation + expectation;
                if ((out_ > 10)||(out_ < 0))
                {
                    out_ = NextDouble();
                }
                return out_;
            }
        }

        private NormalRandom Gaus;
        public int Id { get; set; }
        public CCultivator.CStats MinStats { get; set; }
        public CCultivator.CStats MaxStats { get; set; }
        // G - переменная от 0 до 10,по сути величина, выпадающая чаще всего
        CEquipmentGenerator(int id, CCultivator.CStats min, CCultivator.CStats max,double G)
        {
            Id = id;
            MinStats = min;
            MaxStats = max;
            Gaus = new NormalRandom(2.2,G);
        }

        public override CEquipmentInventory Generate()
        {
            CCultivator.CStats out_ = MinStats.Copy();
            float scale = Gaus.Next() / 10;
            out_.MainStats.Agility = (float)Math.Round(out_.MainStats.Agility + (MaxStats.MainStats.Agility-out_.MainStats.Agility)*scale);
            out_.MainStats.Endurance += (float)Math.Round((MaxStats.MainStats.Endurance - out_.MainStats.Endurance) * scale);
            out_.MainStats.Intelligence += (float)Math.Round((MaxStats.MainStats.Intelligence - out_.MainStats.Intelligence) * scale);
            out_.MainStats.Strength += (float)Math.Round((MaxStats.MainStats.Strength - out_.MainStats.Strength) * scale);
            out_.SubStats.Charisma += (float)Math.Round((MaxStats.SubStats.Charisma - out_.SubStats.Charisma) * scale);
            out_.SubStats.Luck += (float)Math.Round((MaxStats.SubStats.Luck - out_.SubStats.Luck) * scale);
            out_.SubStats.Perception += (float)Math.Round((MaxStats.SubStats.Perception - out_.SubStats.Perception) * scale);
            out_.Scales.Agility *= (MaxStats.Scales.Agility - out_.Scales.Agility) * scale;
            out_.Scales.Endurance *= (MaxStats.Scales.Endurance - out_.Scales.Endurance) * scale;
            out_.Scales.Intelligence *= (MaxStats.Scales.Intelligence - out_.Scales.Intelligence) * scale;
            out_.Scales.Strength *= (MaxStats.Scales.Strength - out_.Scales.Strength) * scale;
            return new T
            {
                Bonus = out_,
                Count = 1,
                Id = Id
            };
        }
    }
}