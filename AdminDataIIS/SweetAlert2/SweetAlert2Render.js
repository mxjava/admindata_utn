function SweetAlert2($)
{
	this.Width;
	this.Height;
	this.Propiedades;

	// Databinding for property Propiedades
	this.SetPropiedades = function(data)
	{
		///UserCodeRegionStart:[SetPropiedades] (do not remove this comment.)
		this.Propiedades = data;

		
		
		
		///UserCodeRegionEnd: (do not remove this comment.)
	}

	// Databinding for property Propiedades
	this.GetPropiedades = function()
	{
		///UserCodeRegionStart:[GetPropiedades] (do not remove this comment.)
		return this.Propiedades;

		
		
		
		///UserCodeRegionEnd: (do not remove this comment.)
	}

	this.show = function()
	{
		///UserCodeRegionStart:[show] (do not remove this comment.)


		
		
		
		
		
		
		
		///UserCodeRegionEnd: (do not remove this comment.)
	}
	///UserCodeRegionStart:[User Functions] (do not remove this comment.)
	this.showAlert = function() {
		Swal.fire({
		title: this.Propiedades.title,
		text: this.Propiedades.text,
		html: this.Propiedades.html,
		icon: this.Propiedades.icon,
		focusConfirm: this.Propiedades.focusConfirm,
		showCancelButton: this.Propiedades.showCancelButton,
		showCloseButton: this.Propiedades.showCloseButton,
		showConfirmButton: this.Propiedades.showConfirmButton,
		confirmButtonColor: this.Propiedades.confirmButtonColor,
		cancelButtonColor: this.Propiedades.cancelButtonColor,
		confirmButtonText: this.Propiedades.confirmButtonText,
		cancelButtonText: this.Propiedades.cancelButtonText,
		allowOutsideClick: this.Propiedades.allowOutsideClick,
		footer: this.Propiedades.footer
		}).then((result) => {
			if (result.isConfirmed && this.Propiedades.confirmButtonUrl) {
				window.location = this.Propiedades.confirmButtonUrl
			} else if (result.isConfirmed) {
				this.OnAccept();
			} else if (result.dismiss === Swal.DismissReason.cancel) {
				this.OnCancel();
			}
		})
	}
	
	this.OnAccept = function()
	{
		if (typeof(this.Accept) == 'function') {
			this.Accept();
		}
	}

	this.OnCancel = function()
	{
		if (typeof(this.Cancel) == 'function') {
			this.Cancel();
		}
	}
	
	
	
	
	
	///UserCodeRegionEnd: (do not remove this comment.):
}
