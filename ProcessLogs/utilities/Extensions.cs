using System.Windows.Forms;
using System;
using System.Collections.Generic;

public static class Extensions
{
    //Method to add text along with new line to rich text box
    public static void AppendTextWithNewLine(this TextBoxBase textBox, string text)
    {
        textBox.AppendText(text + Environment.NewLine);
    }


    internal static void RunUpdater(this Control uiElement, Action updater, bool checkHandleCreated)
    {
        // Do nothing if the handle isn't created already.  The user's responsible for ensuring that the handle they give us exists.
        if (checkHandleCreated && !uiElement.IsHandleCreated) 
            return;

        if (uiElement.IsDisposed) throw new ObjectDisposedException("Control is already disposed.");
        updater();
    }

    

    public static void SafeInvoke(this Control uiElement, Action updater, bool forceSynchronous = true, bool checkHandleCreated = true)
    {
        if (uiElement == null)
            throw new ArgumentNullException(nameof(uiElement));

        if (uiElement.InvokeRequired)
        {
            if (forceSynchronous)
            {
                Exception tmpException = null;
                uiElement.Invoke((Action)delegate
                {
                    uiElement.RunUpdater(updater, checkHandleCreated);
                });
                if (tmpException != null)
                    throw new InvalidOperationException("SafeInvoke", tmpException);
            }
            else
                uiElement.BeginInvoke((Action)(() =>
                {
                    uiElement.RunUpdater(updater, checkHandleCreated);
                }));
            return;
        }
        uiElement.RunUpdater(updater, checkHandleCreated);
  

    }


    public static IEnumerable<(int Index, T Value)> Enumerate<T>(this IEnumerable<T> source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        int index = 0;
        foreach (var item in source)
        {
            yield return (index, item);
            index++;
        }
    }



}

