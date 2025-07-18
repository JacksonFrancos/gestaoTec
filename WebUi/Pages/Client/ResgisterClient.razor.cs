using Microsoft.AspNetCore.Components;
using MudBlazor;
using WebUi.Services.Impl;
using WebUi.Services.Interface;

namespace YourAppNamespace.Pages.Clients
{
    public partial class CreateBase : ComponentBase
    {
        [Inject] protected IClientService ClientService { get; set; }
        [Inject] protected ISnackbar Snackbar { get; set; }

        protected string Name { get; set; } = string.Empty;
        protected string Address { get; set; } = string.Empty;
        protected string Email { get; set; } = string.Empty;
        protected int Number { get; set; }

        protected async Task CreateClient()
        {
            var dto = new ClientDTO(
                Name,
                Address,
                Email,
                Number,
                Guid.NewGuid()
            );

            var result = await ClientService.CreateClientAsync(dto);

            if (result.Valid)
            {
                Snackbar.Add("Cliente criado com sucesso!", Severity.Success);
                ClearForm();
            }
            else
            {
                Snackbar.Add(result.Errors.FirstOrDefault()?.Description ?? "Erro ao salvar", Severity.Error);
            }
        }

        private void ClearForm()
        {
            Name = string.Empty;
            Address = string.Empty;
            Email = string.Empty;
            Number = 0;
        }
    }
}