using SnjTextLib;
using SnjTextLib.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SnjTextApp
{
    public partial class SnjTextApp : Form
    {
        private string _processingFile;
        private int _maxPathShownLength = 200;

        private SnjTextLib.Abstract.IProcessorConfig _processorConfig;
        private SnjTextLib.Abstract.ITextProcessor _textProcessor
        {
            get => SnjText.FileProcessor(_processorConfig);
        }

        private IDictionary<string, int> _procesingResult = 
            new Dictionary<string,int>();

        public SnjTextApp()
        {
            InitializeComponent();
            _processorConfig = SnjText.Config;
        }

        private void SelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Title = "Browse Text Files",
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                _processingFile = fileDialog.FileName;

                var fileLabel =
                    _processingFile.Length > _maxPathShownLength
                        ? _processingFile.Substring(0, _maxPathShownLength)
                        : _processingFile;

                label2.Text = fileDialog.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists(_processingFile))
            {
                dataGridView1.Visible = false;

                var result = 
                    _textProcessor
                        .Process(_processingFile)
                        .OrderByDescending(o => o.Value)
                        .ToDictionary(k => k.Key, v => v.Value);

                if (result != null)
                {
                    _dataWasChanged(result);
                }
            }
        }

        private void _dataWasChanged(IDictionary<string, int> data)
        {
            _procesingResult = data;
            dataGridView1.DataSource = _procesingResult.ToBindingList();
            dataGridView1.Visible = true;
        }
    }
}
