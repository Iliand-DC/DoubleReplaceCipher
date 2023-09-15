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

		TextToMatrix translate = new TextToMatrix(input);

		Coder coder = new Coder(input);

		var new_matrix = coder.Cipher();

		output = translate.MatrixToText(new_matrix);
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

        TextToMatrix translate = new TextToMatrix(input);

        var decode_key_string = DecodeKeyStrings.Text;
		var decode_key_column = DecodeKeyColumns.Text;

		decode_key_string = translate.GetKeyWithSplitter(decode_key_string);
        decode_key_column = translate.GetKeyWithSplitter(decode_key_column);

        int[] keyString = decode_key_string.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
        int[] keyColumn = decode_key_column.Split(',').Select(n => Convert.ToInt32(n)).ToArray();

        Console.WriteLine(keyString);
        Console.WriteLine(keyColumn);

        Decoder decoder = new Decoder(keyString,keyColumn,translate.GetMatrix(),translate.GetSize());

		var new_matrix = decoder.Decipher();

		output = translate.MatrixToText(new_matrix);

        Input.Text = output;
	}
}


