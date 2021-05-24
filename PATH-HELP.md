# Adding Retriever to PATH on Windows

Retriever comes with an optional CLI application `retriever.exe` that can be added to your system PATH to be used in any terminal on Windows. The steps below will guide you through adding it to your PATH.

1. Copy the full path to your Retriever installation to your clipboard
   - By default, it is located at `C:\Users\USER\AppData\Local\Programs\Caprine Logic`
2. Press <kbd>Windows Key</kbd>+<kbd>S</kbd> and type **path** and then click _Edit the system environment variables_

![Screenshot](https://i.imgur.com/T5TdbMp.png)

3. Click _Environment Variables..._ at the bottom of the dialog box that appears

![Screenshot](https://i.imgur.com/C8o9rNU.png)

4. Under _System variables_ at the bottom half of the dialog, scroll until you find a variable named **Path** and click it, then click the _Edit..._ button

![Screenshot](https://i.imgur.com/UtVVSAj.png)

5. Click the _New_ button at the right side of the new dialog box and paste the full path to your Retriever installation you copied in **step 1**. Click _OK_ on all of the dialog boxes to apply changes

---

Retriever is now in your system PATH and can be executed from any terminal. You may need to restart any terminals that were open during this process for changes to take effect.