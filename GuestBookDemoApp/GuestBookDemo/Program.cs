using GuestBookDemo;

GuestLogic.WelcomeMessage();

var (guests, totalGuests) = GuestLogic.GetAllGuests();

GuestLogic.DisplayGuest(guests);

GuestLogic.DisplayGuestCount(totalGuests);
