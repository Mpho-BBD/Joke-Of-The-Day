import { TestBed } from '@angular/core/testing';

import { AppCookieService } from './cookie.service';

describe('CookieService', () => {
  let service: AppCookieService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AppCookieService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
