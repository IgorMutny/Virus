using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(VirusHesitation))]
public class Virus : Cell
{
    [SerializeField] private List<VirusLeg> _virusLegs;
    [SerializeField] private VirusEyes _virusEyes;

    private VirusHesitation _virusHesitation;

    public override void Initialize(ColorType color)
    {
        base.Initialize(color);

        _virusHesitation = GetComponent<VirusHesitation>();
        _virusHesitation.Initialize();

        _virusEyes.Initialize();
        foreach (VirusLeg virusLeg in _virusLegs)
        { 
            virusLeg.Initialize(ColorDictionary.Get(color));
        }
    }

    private void FixedUpdate()
    {
        _virusHesitation.FixedUpdateExtended();
        _virusEyes.FixedUpdateExtended();
        foreach (VirusLeg virusLeg in _virusLegs)
        {
            virusLeg.FixedUpdateExtended();
        }
    }
}
