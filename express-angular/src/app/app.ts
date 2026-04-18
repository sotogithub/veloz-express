import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css',
  host: {
    // Ensure root component fills the entire viewport
    class: 'flex min-h-full w-full flex-auto flex-col',
  },
})
export class App {
  protected readonly title = signal('express-angular');
}
