using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Adentis.Teste.Fernando.Helpers;
using Adentis.Teste.Fernando.Models;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;

namespace Adentis.Teste.Fernando
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button _button;
        private List<Word> _listWords;

        private RecyclerView _recycler;
        private RecyclerViewAdapter _adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            _recycler = FindViewById<RecyclerView>(Resource.Id.recyclerViewBody);

            _listWords = new List<Word>();

            _button = FindViewById<Button>(Resource.Id.btnSubmitList);
            _button.Click += _btnSubmitList;
        }

        private void _btnSubmitList(object sender, EventArgs e)
        {
            try
            {
                _listWords = new List<Word>();
                string text = FindViewById<EditText>(Resource.Id.textInput).Text;
                string pattern = "[^\\w]";
                string[] words = null;
                int i = 0;

                words = Regex.Split(text, pattern, RegexOptions.IgnoreCase);

                for (i = words.GetLowerBound(0); i <= words.GetUpperBound(0); i++)
                {
                    string title = words[i].ToString();

                    if (!string.IsNullOrEmpty(title))
                    {
                        Word word = _listWords.Where(m => m.Title.ToUpper() == title.ToUpper()).FirstOrDefault();

                        if (word != null)
                        {
                            word.Count += 1;
                        }
                        else
                        {
                            _listWords.Add(new Word
                            {
                                Count = 1,
                                Title = title
                            });
                        }
                    }
                }

                List<Word> list = _listWords.OrderBy(m => m.Count).ToList();
                _adapter = new RecyclerViewAdapter(list);
                _recycler.SetAdapter(_adapter);
                _recycler.SetLayoutManager(new LinearLayoutManager(this));

            }
            catch (Exception ex)
            {
                Toast.MakeText(Application.Context, ex.Message, ToastLength.Short).Show();
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
