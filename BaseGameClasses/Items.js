((main) =>
{
    class Item
    {
        constructor(name, description, number, rare)
        {
            this["Name"]=name || "0";
            this["Description"]=description || 0;
            this["Number"]=number || 0;
            this["Rare"]=rare || 0;
        }

    }

    class Recipe
    {
        constructor(result, itemsList)
        {
            this["Result"]=result;
            this["ItemsList"]=itemsList;
        }
    }

    if (!main.Game)
    {
        main.Game = {};
    }
    main.Game["ItemsList"] =
        [

        ];
    main.Game["RecipeList"] =
        [

        ];

    main.Game["Item"] = Item;
    main.Game["Recipe"] = Recipe;

})(this);