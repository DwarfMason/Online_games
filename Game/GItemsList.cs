using System;
using System.Collections.Generic;
using WebApplication1.Game.BaseClasses;
using WebApplication1.Game.BaseClasses.Equipment;

namespace WebApplication1.Game
{
    public class GItemsList
    {
        public static SortedList<int, CItemDescription> ItemsList = new SortedList<int, CItemDescription>();

        public static CItemDescription Get(int id)
        {
            return ItemsList[id];
        }

        public static int GetId(string name)
        {
            foreach (var i in ItemsList)
            {
                if (i.Value.Name == name)
                {
                    return i.Value.Id;
                }
            }
            throw new Exception("No Item with this name");
        }

        public static void Add(CItemDescription i)
        {
            ItemsList[i.Id] = i;
        }

        public static void init()
        {
            new CItemDescription(0, "Палка", 
                "Палка, покрытая золотой пылью. Ничего необычного, если бы пыль не была ангельской.",
                "/img/stick.png");
            new CItemDescription(1, "Говно", "отлично совмещается с палками", "/img/govno.png");
            new CItemDescription(2, "Металл", "О! Вот это уже кому-нибудь нужно!", "/img/metall.png");
            new CEquipmentDescription(1000, "Легинсы", "Нет, это не колготки. На кольчугу денег нет!", "/img/leggins.png");
            new CEquipmentDescription(1001, "Подштанники", "И это тоже не колготки! Зато  у меня дети будут!", "/img/underpants.jpg");
            new CEquipmentDescription(1010, "Рубашка", "Возможно сюда впихнем даже адекватное описание", "/img/shirt.png");

            {//swords
                new CEquipmentDescription(1200, "Деревяный меч", "Слабый деревяный меч",
                    "/img/Equipment/Swords/woodsword.png");
                new CEquipmentDescription(1201, "Золотой меч", "Неплохой золотой меч",
                    "/img/Equipment/Swords/goldsword.png");
                new CEquipmentDescription(1202, "Железный меч", "Отличный железный меч",
                    "/img/Equipment/Swords/ironsword.png");
                new CEquipmentDescription(1203, "Каменный меч", "Тяжелый каменный меч",
                    "/img/Equipment/Swords/stoneswords.jpg");
                new CEquipmentDescription(1204, "Алмазный меч", "Невероятно острый алмазный меч",
                    "/img/Equipment/Swords/diamondsword.jpg");
            }

            {//Amulets
                new CEquipmentDescription(1300, "Деревяный aмулет", "Просто деревяшка на веревке, может поможет, может нет",
                    "/img/Equipment/Amulets/woodenamulet.jpg");
                new CEquipmentDescription(1301, "Железный амулет", "Ты чуствуешь какую-то магию от него ",
                    "/img/Equipment/Amulets/ironamulet.jpg");
                new CEquipmentDescription(1302, "Золотой амулет", "Амулет огромной мощи, которая может быть и проклятьем",
                    "/img/Equipment/Amulets/goldenamulet.jpg");
            }
        }
    }
}