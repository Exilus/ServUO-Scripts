using System;
using Server.Items;
using Server.Network;

namespace Server.Mobiles
{
    [CorpseName("remains of a guardian")]
    public class AncientGuardian : BaseCreature
    {
        [Constructable]
        public AncientGuardian() : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.4, 0.8)
        {
            this.Name = "an ancient guardian";
            this.Body = 829;
			this.Hue = 2967;
			
			this.SetStr(975, 1000);
            this.SetDex(80, 90);
            this.SetInt(70, 80);

            this.SetHits(1000, 1500);

            this.SetDamage(45, 65);

            this.SetResistance(ResistanceType.Physical, 90, 100);
            this.SetResistance(ResistanceType.Fire, 90, 100);
            this.SetResistance(ResistanceType.Cold, 90, 100);
            this.SetResistance(ResistanceType.Poison, 90, 100);
            this.SetResistance(ResistanceType.Energy, 90, 100);

            this.SetSkill(SkillName.MagicResist, 99.0, 100.0);
            this.SetSkill(SkillName.Tactics, 100.0);
            this.SetSkill(SkillName.Wrestling, 100.0);

            this.Fame = 3500;
            this.Karma = -3500;
            this.VirtualArmor = 85;
		}

        public AncientGuardian(Serial serial)
            : base(serial)
        {
        }

        public override bool IsScaredOfScaryThings
        {
            get
            {
                return false;
            }
        }
        public override bool IsScaryToPets
        {
            get
            {
                return true;
            }
        }
        public override bool CanBeDistracted
        {
            get
            {
                return false;
            }
        }
        public override bool AutoDispel
        {
            get
            {
                return true;
            }
        }
        public override bool BleedImmune
        {
            get
            {
                return true;
            }
        }
        public override bool BardImmune
        {
            get
            {
                return true;
            }
        }
        public override Poison PoisonImmune
        {
            get
            {
                return Poison.Lethal;
            }
        }
		public override void GenerateLoot()
        {
            this.AddLoot(LootPack.Average);
        }

        public override int GetAngerSound()
        {
            return 541;
        }

        public override int GetIdleSound()
        {
            return 542;
        }

        public override int GetDeathSound()
        {
            return 545;
        }

        public override int GetAttackSound()
        {
            return 562;
        }

        public override int GetHurtSound()
        {
            return 320;
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
