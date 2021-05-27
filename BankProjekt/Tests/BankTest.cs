using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BankProjekt.Tests
{
    [TestFixture]
    class BankTest
    {
        Bank b;
        [SetUp]
        public void Setup()
        {
            b = new Bank();
        }

        [TestCase]

        public void UjSzamlaHibaNelkulLetrejon()
        {
            Assert.DoesNotThrow(() => b.UjSzamla("Teszt Elek", "1234"));
        }

        [TestCase]
        public void UjSzamlaDuplikaltSzam()
        {
            b.UjSzamla("Teszt Elek", "1234");
            Assert.Throws<ArgumentException>(() => b.UjSzamla("Kovács Elek", "1234"));
        }

        [TestCase]
        public void UjSzamlaLetezoNevvelNincsHiba()
        {
            Assert.DoesNotThrow(() => b.UjSzamla("Teszt Elek", "1234"));
            Assert.DoesNotThrow(() => b.UjSzamla("Teszt Elek", "1235"));
        }

        [TestCase]
        public void EgyenlegFeltoltNemLetezoSzamlaszam()
        {
            b.UjSzamla("Teszt Elek", "1234");
            Assert.Throws<HibasSzamlaszamException>(() => b.EgyenlegFeltolt("4321", 10000));
        }

        [TestCase]
        public void EgyenlegFeltoltLetezoSzamlaszam()
        {
            b.UjSzamla("Teszt Elek", "1234");
            Assert.DoesNotThrow(() => b.EgyenlegFeltolt("4321", 10000));
        }
    }
}
