using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;

namespace Adentis.Teste.Fernando.Helpers
{
    public class RecyclerViewHolder : RecyclerView.ViewHolder
    {
        public TextView Title { get; private set; }
        public TextView Count { get; private set; }

        public RecyclerViewHolder(View itemView) : base(itemView)
        {
            Title = itemView.FindViewById<TextView>(Resource.Id.txtTitle);
            Count = itemView.FindViewById<TextView>(Resource.Id.txtCount);
        }
    }
}

