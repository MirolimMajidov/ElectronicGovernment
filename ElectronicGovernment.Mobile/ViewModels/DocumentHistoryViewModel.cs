using System.Reactive;
using ElectronicGovernment.Mobile.Models;
using ElectronicGovernment.Mobile.Services;
using ReactiveUI;

namespace ElectronicGovernment.Mobile.ViewModels;

public class DocumentHistoryViewModel : BaseViewModel
{
    private Document _displayItems;

    public Document DisplayItems
    {
        get => _displayItems;
        private set => this.RaiseAndSetIfChanged(ref _displayItems, value);
    }

    public ReactiveCommand<Unit, Unit> RefreshCommand { get; }

    public DocumentHistoryViewModel(INavigationService navigationService)
        : base(navigationService)
    {
        RefreshCommand = ReactiveCommand.CreateFromTask(Refresh);
        RefreshCommand.IsExecuting.Subscribe(isRunning => IsBusy = isRunning);
        CatchObservableExceptions(RefreshCommand);
    }

    private Task Refresh()
    {
        IsRefresh = false;
        var activities = GetHistory();
        DisplayItems = activities;
        return Task.CompletedTask;
    }

    public override Task ViewAppearing()
    {
        RefreshCommand.Execute();
        return base.ViewAppearing();
    }

    Document GetHistory()
    {
        return new Document
        {
            Name = "Passport",
            CreatedDate = DateTime.Now,
            Histories =
            [
                new DocumentHistory
                {
                    ActionBy = "Mirolim",
                    Description = "Nice",
                    Status = DocumentStatus.Approved
                },
                new DocumentHistory
                {
                    ActionBy = "Bohirjon",
                    Description = "Nice",
                    Status = DocumentStatus.Approved
                },
                new DocumentHistory
                {
                    ActionBy = "Doniyor",
                    Description = "Nice",
                    Status = DocumentStatus.Approved
                },
                new DocumentHistory
                {
                    ActionBy = "Parvina",
                    Description = "Not necessary documents",
                    Status = DocumentStatus.Rejected
                },
                new DocumentHistory
                {
                    ActionBy = "Tursunhuja",
                    Status = DocumentStatus.Pending
                }
            ]
        };
    }
}