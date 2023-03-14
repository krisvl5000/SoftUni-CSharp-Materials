using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    private Hero hero;
    private Hero heroWithHigherLevel;
    private HeroRepository heroRepository;

    [SetUp]
    public void SetUp()
    {
        hero = new Hero("Name", 10);
        heroWithHigherLevel = new Hero("Higher Level", 15);
        heroRepository = new HeroRepository();
    }

    [Test]
    public void Test_IsRepositoryConstructorWorking()
    {
        Assert.That(heroRepository.Heroes.Count == 0);
    }

    [Test]
    public void Test_IsCreateHeroThrowingIfTheHeroIsNull()
    {
        hero = null;

        Assert.Throws<ArgumentNullException>(() =>
        {
            heroRepository.Create(hero);
        });
    }

    [Test]
    public void Test_IsCreateHeroThrowingIfTheSameHeroIsAdded()
    {
        heroRepository.Create(hero);

        Assert.Throws<InvalidOperationException>(() =>
        {
            heroRepository.Create(hero);
        });
    }

    [Test]
    public void Test_CreateHeroWorking()
    {
        heroRepository.Create(hero);
        Assert.That(heroRepository.Heroes.Count == 1);
    }

    [Test]
    public void Test_IsRemoveHeroThrowingIfTheNameIsNullOrWhitespace()
    {
        heroRepository.Create(hero);
        Assert.Throws<ArgumentNullException>(() =>
        {
            heroRepository.Remove("");
        });
    }

    [Test]
    public void Test_IsRemoveHeroReturningFalseIfThereIsNoSuchHero()
    {
        heroRepository.Create(hero);
        Assert.That(heroRepository.Remove("Other name") == false);
    }

    [Test]
    public void Test_IsRemoveHeroReturningTrueIfHeroWasRemoved()
    {
        heroRepository.Create(hero);

        Assert.That(heroRepository.Remove("Name") && heroRepository.Heroes.Count == 0);
    }

    [Test]
    public void Test_IsGetHeroWithTheHighestLevelWorking()
    {
        heroRepository.Create(hero);
        heroRepository.Create(heroWithHigherLevel);

        Assert.That(heroRepository.GetHeroWithHighestLevel().Name == heroWithHigherLevel.Name);
    }

    [Test]
    public void Test_IsGetHeroWorking()
    {
        heroRepository.Create(hero);
        heroRepository.Create(heroWithHigherLevel);

        Assert.That(heroRepository.GetHero("Name").Name == hero.Name);
    }
}