using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlApi;
using LightManagement.ModelView;

namespace LightManagement.Pages;

public partial class Setup : ContentPage
{
    public Setup()
    {
        InitializeComponent();
        BindingContext = new SetupModel();
    }
    
}