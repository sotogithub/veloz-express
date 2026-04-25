import {
  afterNextRender,
  Component,
  HostListener,
  signal,
} from '@angular/core';
import { RouterLink } from '@angular/router';

interface NavLink {
  id: string;
  href: string;
  label: string;
}

@Component({
  selector: 'app-header-website',
  imports: [RouterLink],
  host: {
    class:
      'fixed inset-x-0 top-0 z-50 transition-all duration-300 ease-out',
    '[class.bg-white/85]': 'scrolled()',
    '[class.shadow-[0_10px_40px_-15px_rgba(15,23,42,0.15)]]': 'scrolled()',
    '[class.border-slate-200/70]': 'scrolled()',
    '[class.bg-white/60]': '!scrolled()',
    '[class.border-transparent]': '!scrolled()',
    '[class.border-b]': 'true',
    '[class.backdrop-blur-xl]': 'true',
  },
  template: `
    <nav
      class="mx-auto flex max-w-7xl items-center justify-between px-6 transition-all duration-300 lg:px-8"
      [class.h-16]="scrolled()"
      [class.h-20]="!scrolled()"
      aria-label="Navegación principal"
    >
      <a
        [routerLink]="'/'"
        class="group flex items-center gap-2.5 outline-none"
        aria-label="Ir al inicio VelozExpress"
      >
        <div
          class="relative flex h-10 w-10 items-center justify-center rounded-2xl bg-linear-to-br from-orange-500 to-rose-500 shadow-lg shadow-orange-500/30 transition-transform duration-300 group-hover:-rotate-6 group-hover:scale-105 group-focus-visible:ring-2 group-focus-visible:ring-orange-400 group-focus-visible:ring-offset-2"
        >
          <svg
            class="h-5 w-5 text-white transition-transform duration-300 group-hover:translate-x-0.5"
            viewBox="0 0 24 24"
            fill="none"
            stroke="currentColor"
            stroke-width="2.5"
            stroke-linecap="round"
            stroke-linejoin="round"
          >
            <path d="M3 12h14l-3-3m3 3-3 3" />
            <circle cx="19" cy="6" r="2" />
          </svg>
          <span
            class="absolute inset-0 rounded-2xl bg-linear-to-br from-orange-400 to-rose-400 opacity-0 blur-lg transition-opacity duration-300 group-hover:opacity-60"
            aria-hidden="true"
          ></span>
        </div>
        <span class="text-xl font-bold tracking-tight text-slate-900">
          Veloz<span class="text-orange-500">Express</span>
        </span>
      </a>

      <div
        class="relative hidden items-center rounded-full border border-slate-200/70 bg-white/60 px-2 py-1.5 shadow-sm shadow-slate-900/5 md:flex"
        role="menubar"
      >
        @for (link of links; track link.id) {
          <a
            [href]="link.href"
            role="menuitem"
            class="relative rounded-full px-4 py-1.5 text-sm font-medium transition-colors duration-200 outline-none focus-visible:ring-2 focus-visible:ring-orange-400"
            [class.text-slate-900]="activeSection() === link.id"
            [class.text-slate-600]="activeSection() !== link.id"
            [class.hover:text-slate-900]="activeSection() !== link.id"
          >
            @if (activeSection() === link.id) {
              <span
                class="absolute inset-0 -z-10 rounded-full bg-slate-900/5"
                aria-hidden="true"
              ></span>
            }
            {{ link.label }}
          </a>
        }
      </div>

      <div class="flex items-center gap-2">
        <a
          [routerLink]="'/admin'"
          class="hidden rounded-full px-4 py-2 text-sm font-medium text-slate-700 transition-colors hover:bg-slate-900/5 hover:text-slate-900 focus-visible:ring-2 focus-visible:ring-orange-400 focus-visible:outline-none sm:inline-flex"
        >
          Ingresar
        </a>
        <a
          href="#registrar"
          class="group inline-flex items-center gap-1.5 rounded-full bg-slate-900 px-4 py-2.5 text-sm font-semibold text-white shadow-sm shadow-slate-900/20 transition-all duration-200 hover:-translate-y-0.5 hover:bg-slate-800 hover:shadow-lg hover:shadow-slate-900/20 focus-visible:ring-2 focus-visible:ring-orange-400 focus-visible:ring-offset-2 focus-visible:outline-none"
        >
          Enviar ahora
          <svg
            class="h-4 w-4 transition-transform duration-200 group-hover:translate-x-0.5"
            viewBox="0 0 24 24"
            fill="none"
            stroke="currentColor"
            stroke-width="2"
            stroke-linecap="round"
            stroke-linejoin="round"
          >
            <path d="M5 12h14m-6-6 6 6-6 6" />
          </svg>
        </a>

        <button
          type="button"
          (click)="toggleMobile()"
          [attr.aria-expanded]="mobileOpen()"
          aria-controls="mobile-nav"
          aria-label="Abrir menú"
          class="relative flex h-10 w-10 items-center justify-center rounded-full border border-slate-200/70 bg-white/70 text-slate-700 transition-colors hover:bg-slate-900/5 focus-visible:ring-2 focus-visible:ring-orange-400 focus-visible:outline-none md:hidden"
        >
          <span class="sr-only">Menú</span>
          <span
            class="absolute block h-0.5 w-5 rounded-full bg-current transition-all duration-300"
            [class.translate-y-[-5px]]="!mobileOpen()"
            [class.rotate-45]="mobileOpen()"
          ></span>
          <span
            class="absolute block h-0.5 w-5 rounded-full bg-current transition-opacity duration-200"
            [class.opacity-0]="mobileOpen()"
          ></span>
          <span
            class="absolute block h-0.5 w-5 rounded-full bg-current transition-all duration-300"
            [class.translate-y-[5px]]="!mobileOpen()"
            [class.-rotate-45]="mobileOpen()"
          ></span>
        </button>
      </div>
    </nav>

    <div
      id="mobile-nav"
      class="overflow-hidden border-t border-slate-200/60 bg-white/95 backdrop-blur-xl transition-[max-height,opacity] duration-300 ease-out md:hidden"
      [class.max-h-0]="!mobileOpen()"
      [class.opacity-0]="!mobileOpen()"
      [class.max-h-96]="mobileOpen()"
      [class.opacity-100]="mobileOpen()"
      [attr.aria-hidden]="!mobileOpen()"
    >
      <div class="flex flex-col gap-1 px-6 py-4">
        @for (link of links; track link.id; let i = $index) {
          <a
            [href]="link.href"
            (click)="closeMobile()"
            class="flex items-center justify-between rounded-xl px-4 py-3 text-base font-medium transition-colors"
            [class.bg-slate-900/5]="activeSection() === link.id"
            [class.text-slate-900]="activeSection() === link.id"
            [class.text-slate-600]="activeSection() !== link.id"
            [class.hover:bg-slate-900/5]="activeSection() !== link.id"
            [style.transition-delay.ms]="mobileOpen() ? i * 40 : 0"
          >
            {{ link.label }}
            <svg
              class="h-4 w-4 text-slate-400"
              viewBox="0 0 24 24"
              fill="none"
              stroke="currentColor"
              stroke-width="2"
              stroke-linecap="round"
              stroke-linejoin="round"
            >
              <path d="m9 6 6 6-6 6" />
            </svg>
          </a>
        }
        <a
          [routerLink]="'/admin'"
          (click)="closeMobile()"
          class="mt-2 rounded-xl border border-slate-200 px-4 py-3 text-center text-sm font-medium text-slate-700 transition-colors hover:bg-slate-50"
        >
          Ingresar
        </a>
      </div>
    </div>
  `,
})
export class HeaderWebsite {
  protected readonly scrolled = signal(false);
  protected readonly mobileOpen = signal(false);
  protected readonly activeSection = signal<string>('');

  protected readonly links: NavLink[] = [
    { id: 'servicios', href: '#servicios', label: 'Servicios' },
    { id: 'proceso', href: '#proceso', label: 'Cómo funciona' },
    { id: 'beneficios', href: '#beneficios', label: 'Beneficios' },
    { id: 'contacto', href: '#contacto', label: 'Contacto' },
  ];

  constructor() {
    afterNextRender(() => {
      this.scrolled.set(window.scrollY > 8);

      const observer = new IntersectionObserver(
        (entries) => {
          const visible = entries
            .filter((e) => e.isIntersecting)
            .sort((a, b) => b.intersectionRatio - a.intersectionRatio)[0];
          if (visible) {
            this.activeSection.set(visible.target.id);
          }
        },
        { rootMargin: '-35% 0px -55% 0px', threshold: [0, 0.25, 0.5, 1] },
      );

      for (const link of this.links) {
        const el = document.getElementById(link.id);
        if (el) observer.observe(el);
      }
    });
  }

  @HostListener('window:scroll')
  protected onScroll(): void {
    this.scrolled.set(window.scrollY > 8);
  }

  @HostListener('document:keydown.escape')
  protected onEscape(): void {
    this.mobileOpen.set(false);
  }

  protected toggleMobile(): void {
    this.mobileOpen.update((v) => !v);
  }

  protected closeMobile(): void {
    this.mobileOpen.set(false);
  }
}
