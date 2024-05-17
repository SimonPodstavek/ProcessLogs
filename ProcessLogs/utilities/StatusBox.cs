using System.Windows.Forms;
using System;

public static class StatusBoxHelper
{
    public static void AppendTextWithNewLine(this TextBoxBase textBox, string text)
    {
        textBox.AppendText(text + Environment.NewLine);
    }
}
