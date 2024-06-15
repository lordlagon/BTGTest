namespace Core;

public partial class ItemCustomerView : Border
{
	public ItemCustomerView()
	{
		InitializeComponent();
	}
    #region Name
    public static readonly BindableProperty NameProperty = BindableProperty.Create(
        propertyName: nameof(Name),
        returnType: typeof(string),
        declaringType: typeof(ItemCustomerView),
        defaultValue: string.Empty,
        defaultBindingMode: BindingMode.TwoWay);
    public string Name
    {
        get => (string)GetValue(NameProperty);
        set => SetValue(NameProperty, value);
    }
    #endregion
    #region LastName
    public static readonly BindableProperty LastNameProperty = BindableProperty.Create(
        propertyName: nameof(LastName),
        returnType: typeof(string),
        declaringType: typeof(ItemCustomerView),
        defaultValue: string.Empty,
        defaultBindingMode: BindingMode.TwoWay);
    public string LastName
    {
        get => (string)GetValue(LastNameProperty);
        set => SetValue(LastNameProperty, value);
    }
    #endregion
    #region Address
    public static readonly BindableProperty AddressProperty = BindableProperty.Create(
        propertyName: nameof(Address),
        returnType: typeof(string),
        declaringType: typeof(ItemCustomerView),
        defaultValue: string.Empty,
        defaultBindingMode: BindingMode.TwoWay);
    public string Address
    {
        get => (string)GetValue(AddressProperty);
        set => SetValue(AddressProperty, value);
    }
    #endregion
    #region Age
    public static readonly BindableProperty AgeProperty = BindableProperty.Create(
        propertyName: nameof(Age),
        returnType: typeof(int),
        declaringType: typeof(ItemCustomerView),
        defaultValue: 0,
        defaultBindingMode: BindingMode.TwoWay);
    public int Age
    {
        get => (int)GetValue(AgeProperty);
        set => SetValue(AgeProperty, value);
    }
    #endregion

    #region Commands
    public static readonly BindableProperty EditCommandProperty = BindableProperty.Create(
        propertyName: nameof(EditCommand),
        returnType: typeof(ICommand),
        declaringType: typeof(ItemCustomerView),
        defaultValue: null,
        defaultBindingMode: BindingMode.TwoWay
        );

    public ICommand EditCommand
    {
        get => (ICommand)GetValue(EditCommandProperty);
        set => SetValue(EditCommandProperty, value);
    }
    public static readonly BindableProperty DeleteCommandProperty = BindableProperty.Create(
        propertyName: nameof(DeleteCommand),
        returnType: typeof(ICommand),
        declaringType: typeof(ItemCustomerView),
        defaultValue: null,
        defaultBindingMode: BindingMode.TwoWay
        );

    public ICommand DeleteCommand
    {
        get => (ICommand)GetValue(DeleteCommandProperty);
        set => SetValue(DeleteCommandProperty, value);
    }
    #endregion
    #region CommandParameter
    public static readonly BindableProperty DeleteCommandParameterProperty = BindableProperty.Create(
        propertyName: nameof(DeleteCommandParameter),
        returnType: typeof(object),
        declaringType: typeof(ItemCustomerView),
        defaultValue: null,
        defaultBindingMode: BindingMode.TwoWay);
    public object DeleteCommandParameter
    {
        get => (object)GetValue(DeleteCommandParameterProperty);
        set => SetValue(DeleteCommandParameterProperty, value);
    }
    public static readonly BindableProperty EditCommandParameterProperty = BindableProperty.Create(
        propertyName: nameof(EditCommandParameter),
        returnType: typeof(object),
        declaringType: typeof(ItemCustomerView),
        defaultValue: null,
        defaultBindingMode: BindingMode.TwoWay);
    public object EditCommandParameter
    {
        get => (object)GetValue(EditCommandParameterProperty);
        set => SetValue(EditCommandParameterProperty, value);
    }
    #endregion
}