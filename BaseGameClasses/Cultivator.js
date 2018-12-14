((main) =>
{
    class Cultivator
    {
        constructor()
        {
            // Константы
            let DefaultInventorySize = 100;
            let DefaultReputationSize = 200;
            let DefaultSkillSize = 125;
            //
            this["Tier"] = 0;
            this["Stage"] = 1;
            this["Hp"] = (new Hp()).init();
            this["Stats"] = new Stats();
            this["DevelopStile"] = new DevelopStile();
            this["Skills"] = new SkillList(DefaultSkillSize);
            this["Reputation"] = new ReputationList(DefaultReputationSize);
            //todo this["KnowledgeOfThePath"]
            //todo this["locationKnowledge"]
            //todo this["MobKnowledge"]
            //todo this["ItemKnowledge"]
            this["Inventory"] = new Inventory(DefaultInventorySize);
        }
    }

    class Stats
    {
        constructor()
        {
            this["MainStats"] = {};
            this["MainStats"]["Strength"] = 0;
            this["MainStats"]["Agility"] = 0;
            this["MainStats"]["Intelligence"] = 0;
            this["MainStats"]["Endurance"] = 0;

            this["MainStats"]["Undistributed"] = 7;

            this["SubStats"] = {};
            this["SubStats"]["Luck"] = 0;
            this["SubStats"]["Charisma"] = 0;
            this["SubStats"]["Perception"] = 0;

            this["SubStats"]["Undistributed"] = 5;

            this["Scales"] = {};
            this["Scales"]["Strength"] = 1;
            this["Scales"]["Agility"] = 1;
            this["Scales"]["Intelligence"] = 1;
            this["Scales"]["Endurance"] = 1;
        }
    }


    class DevelopStile
    {
        constructor()
        {
            //todo Это надо. Хз зачем но 25 лишних констант пригодится,
            this["Stile"] = [
                [0, 0, 0, 0, 0],
                [0, 0, 0, 0, 0],
                [0, 0, 0, 0, 0],
                [0, 0, 0, 0, 0],
                [0, 0, 0, 0, 0]];
        }
    }

    class Inventory
    {
        constructor(size)
        {
            this["ItemList"] = new Array(size);
            this["NumberOfItems"] = 0;

            for (let i = 0; i < size; i++)
            {
                this.ItemList[i] = new main.Game.Item();
            }
        }
    }



    class SkillList
    {
        constructor(number)
        {
            this["List"] = new Array(number);
            for (let i = 0; i < number; i++)
            {
                this.List[i] = Math.ceil(Math.random() * 10);
            }
        }

    }

    class ReputationList
    {
        constructor(number)
        {
            this["List"] = new Array(number);
            for (let i = 0; i < number; i++)
            {
                this.List[i] = 0;
            }
        }
    }
    class Hp
    {
        constructor()
        {
            var p = 0;

            this["MainHp"] = 100;
        }

        init()
        {
            return 100;//todo
            return this;
        };
    }

    if (!main.Game)
    {
        main.Game = {};
    }
    if (!Game["Classes"])
    {
        Game["Classes"] = {};
    }
    main.Game["Classes"]["Cultivator"] = (Cultivator);
    var TestHero = new Cultivator();
    var TestHero2 = new TestHero.__proto__.constructor();
})(this)
