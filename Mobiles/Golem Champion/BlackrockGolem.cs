using System;
using Server.Items;
using Server.Network;

namespace Server.Mobiles
{
    [CorpseName("a blackrock golem corpse")]
    public class BlackrockGolem : BaseCreature
    {
        [Constructable]
        public BlackrockGolem() : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.4, 0.8)
        {
            this.Name = "a blackrock golem";
            this.Body = 829;
			this.Hue = 2019;
			
			this.SetStr(850, 950);
            this.SetDex(184, 250);
            this.SetInt(99, 157);

            this.SetHits(50000);
			this.SetStam(275, 375);

            this.SetDamage(24, 33);
			
			this.SetDamageType(ResistanceType.Physical, 25);
            this.SetDamageType(ResistanceType.Energy, 75);

            this.SetResistance(ResistanceType.Physical, 100);
            this.SetResistance(ResistanceType.Fire, 95, 100);
            this.SetResistance(ResistanceType.Cold, 65, 75);
            this.SetResistance(ResistanceType.Poison, 90, 95);
            this.SetResistance(ResistanceType.Energy, 75, 85);

            this.SetSkill(SkillName.Anatomy, 114.6, 138.7);
            this.SetSkill(SkillName.MagicResist, 154.2, 185.5);
            this.SetSkill(SkillName.Tactics, 115.2, 130.4);
            this.SetSkill(SkillName.Wrestling, 119.7, 138.7);
			
            this.Fame = 3500;
            this.Karma = -3500;
            this.VirtualArmor = 90;
		}
		
		public override bool HasAura { get { return true; } }
        public override int AuraRange { get { return 5; } }
        public override int AuraBaseDamage { get { return 7; } }
        public override int AuraEnergyDamage { get { return 100; } }

		public override void GenerateLoot()
        {
            this.AddLoot(LootPack.UltraRich, 5);
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

		
        public override WeaponAbility GetWeaponAbility()
        {
            switch (Utility.Random(2))
            {
                default:
                case 0:
                    return WeaponAbility.ArmorIgnore;
                case 1:
                    return WeaponAbility.CrushingBlow;
			    case 2:
                    return WeaponAbility.Dismount;
            }
        }
		
		public BlackrockGolem(Serial serial)
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
