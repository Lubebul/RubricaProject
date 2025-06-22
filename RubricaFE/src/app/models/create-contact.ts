export class CreateContact {
  name: string;
  surname: string;
  gender: 0 | 1;
  email: string;
  phoneNumber?: string;
  city?: string;
  birthDate?: string;  // sempre “YYYY-MM-DD”

  constructor(init: {
    name: string;
    surname: string;
    gender: 0 | 1; //0 Male 1 Female
    email: string;
    phoneNumber?: string;
    city?: string;
    birthDate?: string|Date;
  }) {
    this.name       = init.name;
    this.surname    = init.surname;
    this.gender     = init.gender;
    this.email      = init.email;
    this.phoneNumber= init.phoneNumber;
    this.city       = init.city;
    if (init.birthDate) {
      const d = typeof init.birthDate === 'string'
        ? new Date(init.birthDate)
        : init.birthDate;
      const yyyy = d.getFullYear();
      const mm   = String(d.getMonth()+1).padStart(2,'0');
      const dd   = String(d.getDate()).padStart(2,'0');
      this.birthDate = `${yyyy}-${mm}-${dd}`;
    }
  }
}
