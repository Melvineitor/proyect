import { TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { CanActivateFn } from '@angular/router';

import { AuthGuard } from './auth.guard';

describe('AuthGuard', () => {
  let executeGuard: CanActivateFn;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [RouterTestingModule],  // Ensure you have RouterTestingModule imported for routing-related functionality
    });

    // Create the guard instance in the testing context
    executeGuard = (...guardParameters) => 
      TestBed.runInInjectionContext(() => new AuthGuard(...guardParameters));
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });

  it('should activate for authenticated user', async () => {
    // Mock logic for AuthGuard if needed (e.g., simulate a user being authenticated)
    const result = await executeGuard();
    expect(result).toBe(true); // Adjust based on your AuthGuard logic (true/false/GuardResult)
  });

  it('should not activate for unauthenticated user', async () => {
    // Mock logic for unauthenticated state (e.g., simulate no user being logged in)
    const result = await executeGuard();
    expect(result).toBe(false); // Adjust based on your AuthGuard logic
  });
});
