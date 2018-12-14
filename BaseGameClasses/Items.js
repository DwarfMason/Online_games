((main) =>
{
    class ItemDescription
    {
        /**
         * Класс для инициации предметов
         * @param name Название предмета
         * @param description Описание предмета
         * @param rare Редкость предмета //todo
         * @returns {*}
         */
        constructor(name = "0", description = "0", rare = 0)
        {
            if (main.Game["ItemNameArray"].has(name))
                return main.Game["ItemNameArray"].get(name);

            this["Name"] = name;
            this["Description"] = description;
            this["Rare"] = rare;
            this["Id"] = main.Game["ItemIdArray"].size;
            main.Game["ItemNameArray"].set(name, this);
            main.Game["ItemIdArray"].push(this);
        }
    }

    class Item
    {
        constructor(name = "0", number = 0, qual = 100)
        {
            this["Id"] = id;
            this["Number"] = number;
            this["qual"] = [100];
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

    main.Game["Arrays"]["ItemNameArray"] = new Map();
    main.Game["Arrays"]["ItemIdArray"] = new Array();
    main.Game["Classes"]["ItemDescription"] = ItemDescription;
    main.Game["Classes"]["Item"] = Item;

    new ItemDescription();// Инициирование дефолтного предмета //0,0,0,0
})(this);