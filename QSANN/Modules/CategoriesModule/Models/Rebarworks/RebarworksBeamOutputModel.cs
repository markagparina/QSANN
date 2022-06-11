﻿using Prism.Mvvm;

namespace CategoriesModule.Models;

public class RebarworksBeamOutputModel : BindableBase
{
    private string _mainbar;

    public string Mainbar
    {
        get { return _mainbar; }
        set { SetProperty(ref _mainbar, value); }
    }

    private string _lateralTies;

    public string LateralTies
    {
        get { return _lateralTies; }
        set { SetProperty(ref _lateralTies, value); }
    }

    private string _tiewire;

    public string Tiewire
    {
        get { return _tiewire; }
        set { SetProperty(ref _tiewire, value); }
    }

    private string _shortBeamLength;

    public string ShortBeamLength
    {
        get { return _shortBeamLength; }
        set { SetProperty(ref _shortBeamLength, value); }
    }
}