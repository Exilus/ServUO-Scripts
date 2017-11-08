using System;
using Server.Items;

namespace Server.Mobiles 
{ 
    [CorpseName("a corpse")] 
    public class SpectralGuardian : BaseCreature 
    { 
        [Constructable] 
        public SpectralGuardian()
            : base(AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        { 
            this.Name = "a Spectral Guardian";
            this.Body = 400;
            this.Hue = Utility.RandomSkinHue();
			
			
            this.SetStr(96, 120);
            this.SetDex(91, 115);
            this.SetInt(81, 105);

            this.SetHits(149, 163);

            this.SetDamage(15, 20);

            this.SetDamageType(ResistanceType.Physical, 100);

            this.SetResistance(ResistanceType.Physical, 25, 30);
            this.SetResistance(ResistanceType.Fire, 15, 20);
            this.SetResistance(ResistanceType.Poison, 15, 20);
            this.SetResistance(ResistanceType.Energy, 15, 20);

            this.SetSkill(SkillName.Swords, 75.1, 100.0);
            this.SetSkill(SkillName.Anatomy, 75.0, 97.5);
            this.SetSkill(SkillName.Tactics, 65.0, 87.5);
            this.SetSkill(SkillName.MagicResist, 20.2, 60.0);

            this.Fame = 2500;
            this.Karma = -2500;
			this.VirtualArmor = 20;
			
            Item shroud = new HoodedShroudOfShadows();

            shroud.Movable = false;
			
			this.AddItem(new VikingSword());
			this.AddItem(new BronzeShield());
			this.AddItem(new Boots());
		}

        public SpectralGuardian(Serial serial)
            : base(serial)
        {
        }
		
		public override void GenerateLoot()
        {
            this.AddLoot(LootPack.Average);
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