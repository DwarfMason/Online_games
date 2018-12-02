((main) =>
{
    class Skill
    {

        constructor(name,index,description)
        {

            this["name"]=name;
            this["index"]=index;
            this["description"]=description;

        }
    }

    this["SkillList"] = [//todo Типа тут добавлять новые скилы для более удобного вывода в итоге.
        new Skill("Ближний бой",1,
            "Навык ближнего боя, самы важный навык для мили, качается медленно."),
        new Skill("Бой на мечах",2,
            "Навык боя на мечах, необходим мечникам, качается медленно."),
    ];
})(this);