using System;
using Server.Items;
using Server.Network;

namespace Server.Mobiles
{
    [CorpseName("a bone golem corpse")]
    public class BoneGolem : BaseCreature
    {
        [Constructable]
        public BoneGolem() : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.4, 0.8)
        {
            this.Name = "a bone golem";
            this.Body = 309;
			
			this.SetStr(800, 900);
            this.SetDex(400, 441);
            this.SetInt(94, 144);

            this.SetHits(800, 900);

            this.SetDamage(18, 20);
			
			this.SetDamageType(ResistanceType.Physical, 100);

            this.SetResistance(ResistanceType.Physical, 90);
            this.SetResistance(ResistanceType.Fire, 15, 20);
            this.SetResistance(ResistanceType.Cold, 80);
            this.SetResistance(ResistanceType.Poison, 100);
            this.SetResistance(ResistanceType.Energy, 90);

            this.SetSkill(SkillName.MagicResist, 80.0, 90.0);
            this.SetSkill(SkillName.Tactics, 90.0, 100.0);
            this.SetSkill(SkillName.Wrestling, 90.0, 100.0);

            this.Fame = 3500;
            this.Karma = -3500;
            this.VirtualArmor = 75;
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
		
		public BoneGolem(Serial serial)
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