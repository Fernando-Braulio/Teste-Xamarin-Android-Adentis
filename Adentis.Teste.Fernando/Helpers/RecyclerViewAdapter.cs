using Android.Views;
using AndroidX.RecyclerView.Widget;
using System.Collections.Generic;
using Adentis.Teste.Fernando.Models;

namespace Adentis.Teste.Fernando.Helpers
{
    public class RecyclerViewAdapter : RecyclerView.Adapter
    {
        private List<Word> _words;

        public RecyclerViewAdapter(List<Word> words)
        {
            _words = words;
        }

        public override int ItemCount => _words == null ? 0 : _words.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            RecyclerViewHolder vh = holder as RecyclerViewHolder;

            vh.Title.Text = _words[position].Title;
            vh.Count.Text = _words[position].Count.ToString();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.activity_item, parent, false);
            return new RecyclerViewHolder(itemView);
        }
    }
}
