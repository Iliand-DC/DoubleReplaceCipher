namespace DoubleReplace;

public partial class MainPage : ContentPage
{
	string input = "";
	string output = "";
	public MainPage()
	{
		InitializeComponent();
	}
	void Code_Clicked(object sender, EventArgs e)
	{
		input = Input.Text;
		Coder coder = new Coder(input);
		var new_matrix = coder.Cipher();

		output = coder.MatrixToText(new_matrix);
		Output.Text = output;

		KeyStrings.Text = coder.GetKeyString();
		KeyColumns.Text = coder.GetKeyColumn();

		DecodeKeyStrings.Text = KeyStrings.Text;
		DecodeKeyColumns.Text = KeyColumns.Text;

		Input.Text = "";
	}
	void Decode_Clicked(object sender, EventArgs e)
	{
		input = Output.Text;
		var decode_key_string = DecodeKeyStrings.Text;
		var decode_key_column = DecodeKeyColumns.Text;
		Coder coder = new Coder(input);


		decode_key_string = coder.GetKeyWithSplitter(decode_key_string);


        int[] keyString = decode_key_string.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
		int[] keyColumn = decode_key_column.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
		Console.WriteLine(keyString);
		Console.WriteLine(keyColumn);


		var old_matrix = coder.Decipher(keyString, keyColumn);
		output = coder.MatrixToText(old_matrix);


        Input.Text = output;
	}
}


