namespace Razer.AccountManager
{
	public enum WarrantyResult
	{
		UnsupportedProductCode = -22,
		PurchaseDateTooEarly,
		HideFailed,
		RegistrationLookupFailed,
		NotApplicable,
		NotAllowed,
		RendemptionLookupFailed,
		DurationLookupFailed,
		ActivationFailed,
		InvalidProductCode,
		InvalidCountry,
		InvalidPurchaseDate,
		InvalidLocation,
		SerialNumberMismatch,
		PastWarrantyExtension,
		CodeAlreadyUsed,
		UnknownCode,
		CodeApplicationFailed,
		ItemBelongsToAnotherUser,
		UnknownSerialNumber,
		UnknownItem,
		RegistrationFailed,
		AlreadyRegistered,
		Success,
		NotRegistered,
		ExtensionSuccessful,
		ItemActive,
		AlreadyActive,
		ItemHidden,
		ItemAlreadyHidden
	}
}
