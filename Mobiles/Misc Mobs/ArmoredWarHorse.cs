using System;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("an armored warhorse corpse")]
    public class ArmoredWarHorse : BaseMount
    {
        [Constructable]
        public ArmoredWarHorse()
            : this("an armored warhorse")
        {
        }
		
		[Constructable]
        public ArmoredWarHorse(string name)
            : base(name, 0x74, 0x3EA7, AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            this.Body = 284;
            this.BaseSoundID = Core.AOS ? 0xA8 : 0x16A;

            this.SetStr(1025, 1425);
            this.SetDex(81, 148);
            this.SetInt(675, 875);

            this.SetHits(2000, 3000);
            this.SetStam(120, 135);

            this.SetDamage(34, 44);

            this.SetDamageType(ResistanceType.Physical, 100);

            this.SetResistance(ResistanceType.Physical, 60, 85);
            this.SetResistance(ResistanceType.Fire, 65, 90);
            this.SetResistance(ResistanceType.Cold, 50, 75);
            this.SetResistance(ResistanceType.Poison, 40, 60);
            this.SetResistance(ResistanceType.Energy, 50, 75);

            this.SetSkill(SkillName.Meditation, 110.0, 140.0);
            this.SetSkill(SkillName.EvalInt, 110.0, 140.0);
            this.SetSkill(SkillName.Magery, 110.0, 140.0);
            this.SetSkill(SkillName.Poisoning, 0);
            this.SetSkill(SkillName.Anatomy, 110.0, 140.0);
            this.SetSkill(SkillName.MagicResist, 110.0, 140.0);
            this.SetSkill(SkillName.Tactics, 110.0, 140.0);
            this.SetSkill(SkillName.Wrestling, 115.0, 145.0);

            this.Fame = 22000;
            this.Karma = -15000;

            this.VirtualArmor = 60;

            this.Tamable = true;
            this.ControlSlots = 5;
            this.MinTameSkill = 104.7;
        }

        public ArmoredWarHorse(Serial serial)
            : base(serial)
        {
        }

        public override bool StatLossAfterTame
        {
            get
            {
                return false;
            }
        }
        public override bool ReacquireOnMovement
        {
            get
            {
                return !this.Controlled;
            }
        }
        public override bool HasBreath
        {
            get
            {
                return true;
            }
        }// fire breath enabled
        public override bool AutoDispel
        {
            get
            {
                return !this.Controlled;
            }
        }
        public override int TreasureMapLevel
        {
            get
            {
                return 5;
            }
        }
        public override int Meat
        {
            get
            {
                return 19;
            }
        }
        public override int Hides
        {
            get
            {
                return 30;
            }
        }
        public override HideType HideType
        {
            get
            {
                return HideType.Barbed;
            }
        }

        public override FoodType FavoriteFood
        {
            get
            {
                return FoodType.Meat;
            }
        }
        public override bool CanAngerOnTame
        {
            get
            {
                return true;
            }
        }
        public override bool CanFly
        {
            get
            {
                return true;
            }
        }
        public override void GenerateLoot()
        {
            this.AddLoot(LootPack.FilthyRich, 4);
            this.AddLoot(LootPack.Gems, 8);
        }

        public override WeaponAbility GetWeaponAbility()
        {
            return WeaponAbility.BleedAttack;
        }
		
	    public override int GetAngerSound()
        {
            if (!this.Controlled)
                return 0x16A;

            return base.GetAngerSound();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)1);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            if (Core.AOS && this.BaseSoundID == 0x16A)
                this.BaseSoundID = 0xA8;
            else if (!Core.AOS && this.BaseSoundID == 0xA8)
                this.BaseSoundID = 0x16A;
        }
    }
}