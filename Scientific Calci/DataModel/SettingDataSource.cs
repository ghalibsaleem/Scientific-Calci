using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage;

namespace Scientific_Calci.DataModel
{

   public class Setting : INotifyPropertyChanged
   {
        //public int UniqueId { get; set; }
        public string Name { get; set; }
        public string Item { get; set; }
       
       //private string item;

        //public string Item
        //{       
        //    get { return Item;}
        //    set {
        //            if (value != this.item)
        //            {
        //                item = value;
        //                NotifyPropertyChanged("Item");
        //            }
        //        }
        //}
        

        //public Setting(int unique_id,string item){
        //    this.UniqueId=unique_id;
        //    this.Item=item;
        //}


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyname)
        {
            if(PropertyChanged != null){
                PropertyChanged(this,new PropertyChangedEventArgs(propertyname));
            }
        }
   }
    public class SettingDataSource
    {
        

        //private static SettingDataSource _settingdatasource = new SettingDataSource();

        private ObservableCollection<Setting> _settings;
        const string FileName = "Setting.json";
        public SettingDataSource(){
            _settings = new ObservableCollection<Setting>();
        }

        public async Task<ObservableCollection<Setting>> GetSetting()
        {
           await ensureDataLoaded();
            if(_settings.Count == 0){
                Setting Angle  = new Setting();
                Angle.Name = "Angle";
                Angle.Item = "Degree";
                _settings.Add(Angle);

                Setting Rating = new Setting();
                Rating.Name = "Rating";
                Rating.Item = "0";
                _settings.Add(Rating);

                Setting Shift = new Setting();
                Shift.Name = "Shift";
                Shift.Item = "on";
                _settings.Add(Shift);

                Setting Memory = new Setting();
                Memory.Name = "Memory";
                Memory.Item = "0.0";
                _settings.Add(Memory);
                await setSettingDataAsync();
                
            }
            return _settings;
        }
        private async Task ensureDataLoaded()
        {
            if (_settings.Count == 0)
                await getSettingDataAsync();
            return;
        }

        private async Task getSettingDataAsync()
        {
            if (_settings.Count != 0)
                return;

            var jsonserializer = new DataContractJsonSerializer(typeof(ObservableCollection<Setting>));
            try
            {
                
                using(var stream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(FileName)){
                    _settings = (ObservableCollection<Setting>)jsonserializer.ReadObject(stream);
                }
            }
            catch
            {
                _settings = new ObservableCollection<Setting>();
            }
        }

        public async void ChangeSetting(string name,string item)
        {
            Setting setting = new Setting();
            setting.Name = name;
            setting.Item = item;
            if (name == "Angle")
            {
                _settings.Insert(0, setting);
                _settings.RemoveAt(1);
            }
            if (name == "Rating")
            {
                _settings.Insert(1, setting);
                _settings.RemoveAt(2);
            }
            if (name == "Shift")
            {
                _settings.Insert(2, setting);
                _settings.RemoveAt(3);
            }
            if (name == "Memory")
            {
                _settings.Insert(2, setting);
                _settings.RemoveAt(3);
            }
            
           
            
            await setSettingDataAsync();
            
        }

        private async Task setSettingDataAsync()
        {
            var jsonserializer = new DataContractJsonSerializer(typeof(ObservableCollection<Setting>));
            using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(FileName,CreationCollisionOption.ReplaceExisting))
            {
                jsonserializer.WriteObject(stream,_settings);
            }
        }

        //public ObservableCollection<Setting> setting
        //{
        //    get { return this._settings; }
        //}

        //public static async Task<Setting> GetGroupAsync(string uniqueId)
        //{
        //    await _settingdatasource.GetSampleDataAsync();
        //    // Simple linear search is acceptable for small data sets
        //    var matches = _settingdatasource.setting.Where((group) => group.UniqueId.Equals(uniqueId));
        //    if (matches.Count() == 1) return matches.First();
        //    return null;
        //}

        //private async Task GetSampleDataAsync()
        //{
        //    if (this._settings.Count != 0)
        //        return;

        //    Uri dataUri = new Uri("ms-appx:///DataModel/SettingData.json");

        //    StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
        //    string jsonText = await FileIO.ReadTextAsync(file);
        //    JsonObject jsonObject = JsonObject.Parse(jsonText);
        //    JsonArray jsonArray = jsonObject["Groups"].GetArray();

        //    foreach (JsonValue groupValue in jsonArray)
        //    {
        //        JsonObject groupObject = groupValue.GetObject();
        //        Setting group = new Setting(groupObject["UniqueId"].GetString(),
        //                                                    groupObject["item"].GetString());

               
        //        this.setting.Add(group);
        //    }
        //}

        //private async Task SetSettingData()
        //{
        //    var mysetting = buildObjectGraph();
        //    string str = null; 
        //    Stream stream;
        //    Uri dataUri = new Uri("ms-appx:///DataModel/SettingData.json");
        //    StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
        //    var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<Setting>));
        //    await FileIO.WriteTextAsync(file,str);
        //    serializer.WriteObject(stream,)
        //}
    }
}
