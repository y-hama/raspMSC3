using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Imaging
{
    class Storage
    {
        private static Storage instance = new Storage();
        public static Storage Instance { get { return instance; } }
        private Storage() { }

        private const string LAYERFILE_EXTENSION = ".mspi";
        private const string LAYERFILE_SAVELOCATION = @"images\";

        #region LatestFrame
        public object __LatestFrameLock { get; set; } = new object();
        public Image.Layer.Frame LatestFrame { get; set; }
        #endregion

        #region Layer
        private Image.Layer SpectrumLayers { get; set; }

        public void NewObject()
        {
            SpectrumLayers = new Image.Layer();
        }
        public void AddLatestFrameToObject()
        {
            if (SpectrumLayers == null) { return; }
            lock (__LatestFrameLock)
            {
                SpectrumLayers.Add(LatestFrame);
            }
        }

        public void SaveObject(string filename)
        {
            Save(SpectrumLayers, filename);
        }

        public void Save(Image.Layer layer, string filename)
        {
            if (layer == null) { return; }
            if (!Directory.Exists(LAYERFILE_SAVELOCATION))
            {
                Directory.CreateDirectory(LAYERFILE_SAVELOCATION);
            }
            SaveToBinaryFile(layer, LAYERFILE_SAVELOCATION + filename + LAYERFILE_EXTENSION);
        }

        public Image.Layer LoadObject(string filename)
        {
            return (Image.Layer)LoadFromBinaryFile(LAYERFILE_SAVELOCATION + filename + LAYERFILE_EXTENSION);
        }

        public List<string> GetImageNames()
        {
            List<string> res = new List<string>();
            if (!Directory.Exists(LAYERFILE_SAVELOCATION))
            {
                Directory.CreateDirectory(LAYERFILE_SAVELOCATION);
            }
            foreach (var item in (new DirectoryInfo(LAYERFILE_SAVELOCATION)).GetFiles())
            {
                if (item.Extension == LAYERFILE_EXTENSION)
                {
                    res.Add(item.Name.Replace(LAYERFILE_EXTENSION, ""));
                }
            }
            return res;
        }
        #endregion

        #region SaveObjectMethod
        /// <summary>
        /// オブジェクトの内容をファイルに保存する
        /// </summary>
        /// <param name="obj">保存するオブジェクト</param>
        /// <param name="path">保存先のファイル名</param>
        private void SaveToBinaryFile(object obj, string path)
        {
            FileStream fs = new FileStream(path,
                FileMode.Create,
                FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            //シリアル化して書き込む
            bf.Serialize(fs, obj);
            fs.Close();
        }

        /// <summary>
        /// オブジェクトの内容をファイルから読み込み復元する
        /// </summary>
        /// <param name="path">読み込むファイル名</param>
        /// <returns>復元されたオブジェクト</returns>
        private object LoadFromBinaryFile(string path)
        {
            FileStream fs = new FileStream(path,
                FileMode.Open,
                FileAccess.Read);
            BinaryFormatter f = new BinaryFormatter();
            //読み込んで逆シリアル化する
            object obj = f.Deserialize(fs);
            fs.Close();

            return obj;
        }
        #endregion
    }
}
