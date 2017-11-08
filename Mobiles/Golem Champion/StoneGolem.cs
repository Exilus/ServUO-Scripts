using System;
using Server.Items;
using Server.Network;

namespace Server.Mobiles
{
    [CorpseName("a stone golem corpse")]
    public class StoneGolem : BaseCreature
    {
        [Constructable]
        public StoneGolem() : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.4, 0.8)
        {
            this.Name = "a stone golem";
            this.Body = 705;
			this.Hue = 2955;
			
			this.SetStr(850, 950);
            this.SetDex(80, 100);
            this.SetInt(70);

            this.SetHits(515, 580);

            this.SetDamage(26, 35);
			
			this.SetDamageType(ResistanceType.Physical, 100);

            this.SetResistance(ResistanceType.Physical, 100);
            this.SetResistance(ResistanceType.Fire, 89, 90);
            this.SetResistance(ResistanceType.Cold, 69, 75);
            this.SetResistance(ResistanceType.Poison, 100);
            this.SetResistance(ResistanceType.Energy, 35, 45);

            this.SetSkill(SkillName.MagicResist, 167.5, 176.4);
            this.SetSkill(SkillName.Tactics, 85.0, 118.8);
            this.SetSkill(SkillName.Wrestling, 90.0, 108.6);

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
		
		public StoneGolem(Serial serial)
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