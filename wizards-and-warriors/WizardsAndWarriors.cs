using System;

abstract class Character {
    private readonly string _characterType;

    protected Character(string characterType) {
        _characterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable() {
        return false;
    }

    public override string ToString() {
        return $"Character is a {_characterType}";
    }
}

class Warrior : Character {
    public Warrior() : base("Warrior") {
    }

    public override int DamagePoints(Character target) {
        return target.Vulnerable() ? 10 : 6;
    }
}

class Wizard : Character {

    private bool _spellPrepared;
    
    public Wizard() : base("Wizard") {
        // Spell is not prepared by default
        _spellPrepared = false;
    }

    public override int DamagePoints(Character target) {
        return _spellPrepared ? 12 : 3;
    }

    public void PrepareSpell() {
        // Wizard has prepared the spell
        _spellPrepared = true;
    }

    public override bool Vulnerable() {
        // Wizards are vulnerable based on spell preparation
        return !_spellPrepared;
    }
}
