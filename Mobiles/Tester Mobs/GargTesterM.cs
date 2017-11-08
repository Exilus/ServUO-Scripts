using System;
using Server.Items;

namespace Server.Mobiles 
{ 
    [CorpseName("a gargish corpse")] 
    public class GargoyleTesterM : BaseCreature 
    { 
        [Constructable] 
        public GargoyleTesterM()
            : base(AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        { 
            this.Name = "Gargoyle Test Body [Male]";
            this.Body = 666;
			
            this.SetStr(100);
            this.SetDex(100);
            this.SetInt(100);

            this.SetHits(100);

            this.SetDamage(10, 20);

            this.SetDamageType(ResistanceType.Physical, 100);

            this.SetResistance(ResistanceType.Physical, 100);
            this.SetResistance(ResistanceType.Fire, 100);
            this.SetResistance(ResistanceType.Poison, 100);
            this.SetResistance(ResistanceType.Energy, 100);

            this.SetSkill(SkillName.Wrestling, 100);
            this.SetSkill(SkillName.Anatomy, 100);
            this.SetSkill(SkillName.Tactics, 100);
            this.SetSkill(SkillName.MagicResist, 100);
			
            this.Fame = 1000;
            this.Karma = 1000;
			this.VirtualArmor = 20;
		}
			
        public GargoyleTesterM(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}