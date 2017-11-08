using System;
using Server.Items;
using Server.Network;

namespace Server.Mobiles
{
    [CorpseName("an ice golem corpse")]
    public class IceGolem : AuraCreature
    {
        [Constructable]
        public IceGolem() : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.4, 0.8)
        {
            this.Name = "an ice golem";
            this.Body = 705;
			this.Hue = 1266;
			
			this.SetStr(850, 950);
            this.SetDex(80, 100);
            this.SetInt(70);

            this.SetHits(515, 580);

            this.SetDamage(26, 35);
			
			this.SetDamageType(ResistanceType.Physical, 25);
            this.SetDamageType(ResistanceType.Cold, 75);

            this.SetResistance(ResistanceType.Physical, 100);
            this.SetResistance(ResistanceType.Fire, 20);
            this.SetResistance(ResistanceType.Cold, 200);
            this.SetResistance(ResistanceType.Poison, 100);
            this.SetResistance(ResistanceType.Energy, 100);

            this.SetSkill(SkillName.MagicResist, 90.0, 100.0);
            this.SetSkill(SkillName.Tactics, 90.0, 100.0);
            this.SetSkill(SkillName.Wrestling, 90.0, 100.0);
			
            this.Fame = 3500;
            this.Karma = -3500;
            this.VirtualArmor = 80;
		}
		
		public override void GenerateLoot()
        {
            this.AddLoot(LootPack.Average);
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
		
		public IceGolem(Serial serial)
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