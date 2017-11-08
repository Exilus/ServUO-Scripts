using System;
using Server.Items;
using Server.Network;

namespace Server.Mobiles
{
    [CorpseName("an ancient golem corpse")]
    public class RustedGolem : BaseCreature
    {
        [Constructable]
        public RustedGolem() : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.4, 0.8)
        {
            this.Name = "an ancient golem";
            this.Body = 705;
			this.Hue = 2949;
			
			this.SetStr(850, 950);
            this.SetDex(80, 100);
            this.SetInt(70);

            this.SetHits(515, 580);

            this.SetDamage(26, 35);
			
			this.SetDamageType(ResistanceType.Physical, 100);

            this.SetResistance(ResistanceType.Physical, 90);
            this.SetResistance(ResistanceType.Fire, 100);
            this.SetResistance(ResistanceType.Cold, 20);
            this.SetResistance(ResistanceType.Poison, 100);
            this.SetResistance(ResistanceType.Energy, 45);

            this.SetSkill(SkillName.MagicResist, 60.0, 75.0);
            this.SetSkill(SkillName.Tactics, 90.0, 100.0);
            this.SetSkill(SkillName.Wrestling, 90.0, 100.0);

            this.Fame = 3500;
            this.Karma = -3500;
            this.VirtualArmor = 65;
		}

        public override int GetHurtSound() { return 0x627; }
        public override int GetIdleSound() { return 0x629; }
		
	    public override bool BardImmune{ get{ return true; } }
		public override bool Unprovokable{ get{ return true; } }
		public override bool Uncalmable{ get{ return true; } }
		public override bool BleedImmune{ get{ return true; } }
        public override Poison PoisonImmune { get { return Poison.Lethal; } }
		public override Poison HitPoison { get { return Poison.Lethal; } }
        public override Poison HitAreaPoison { get { return Poison.Lethal; } }
		
		public RustedGolem(Serial serial)
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