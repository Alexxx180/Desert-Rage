namespace DesertRage.ViewModel
{
    public interface IViewModelObservable<T>
    {
        public void SetViewModel(T viewModel);
    }
}