((main) =>
{
    class Location
    {
        /**
         * Add new Location
         * @param name Название локации
         * @param description Описание локации
         * @param moblist Массив Id  мобов, которых можно найти на локации
         * @param appearingcance Массив шансов столкновения с мобом на локации, по размеру должен быть равен moblist
         * @param gatheringlist  Массив предметов, добываемых на локации
         * @param requirements Массив требований для посещения локации
         */
        constructor(name = "0", description ="0", moblist = [],appearingcance = [], gatheringlist = [], requirements = [])
        {
            if(Game["Arrays"]["LocationNameArray"][name])
            {
                return Game["Arrays"]["LocationNameArray"][name];
            }
            this["Name"]=name;
            this["Description"]=description;
            this["MobList"]=moblist;
            this["AppearingChance"]=appearingcance;
            this["LegendaryMobList"]=moblist;
            this["LegendaryAppearingChance"]=moblist;
            this["GatheringList"]=gatheringlist;
            this["Requirements"]=requirements;
            this["Id"] = Game["Arrays"]["LocationIdArray"].size;
            Game["Arrays"]["LocationIdArray"].push(this);
            Game["Arrays"]["LocationNameArray"][name]=this;
        }
    }

    class LocationKnowledge
    {
        /**
         *
         * @param id
         */
        constructor(id)
        {
            this["id"]=id;
            this["knowlege"]=0;
        }

    }
    if (!main.Game)
    {
        main.Game = {};
    }
    if (!Game["Classes"])
    {
        Game["Classes"] = {};
    }
    if (!Game["Arrays"])
    {
        Game["Arrays"] = {};
    }

    Game["Classes"]["Location"] =Location;
    Game["Classes"]["LocationKnowledge"] =LocationKnowledge;
    Game["Arrays"]["LocationIdArray"] = new Map();
    Game["Arrays"]["LocationNameArray"] = {};


})(this);