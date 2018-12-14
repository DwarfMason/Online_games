((main) =>
{
    class SkillDescription
    {
        /**
         * Класс для ирнициации пасивных навыков
         * @param name Название навыка
         * @param id Id навыка, не должно повторяться
         * @param description Описание навыка
         * @returns {SkillDescription} В случае если навык с таким именем существует
         */
        constructor(name = "0", id = 0, description = "0")
        {
            if (main.Game["SkillsIdArray"][name])
                return main.Game["SkillsIdArray"][name];
            this["name"] = name;
            this["index"] = id;
            this["description"] = description;
            main.Game["SkillsIdArray"][id] = this;
            main.Game["SkillNameArray"][name] = (this);
        }
    }
    class Skill{}
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

    Game["Classes"]["SkillDescription"] =SkillDescription;
    Game["Classes"]["Skill"] =Skill;
    Game["Arrays"]["SkillsIdArray"] = [];
    Game["Arrays"]["SkillsNameArray"] = {};


})(this);