import { motion } from 'motion/react';
import { ExternalLink, Play, Trophy, Cpu } from 'lucide-react';

export default function Game() {
  return (
    <div className="max-w-7xl mx-auto px-6 py-20 lg:py-32">
      <div className="grid lg:grid-cols-3 gap-16">
        {/* Main Content */}
        <div className="lg:col-span-2 space-y-16">
          <motion.div
            initial={{ opacity: 0, y: 20 }}
            animate={{ opacity: 1, y: 0 }}
          >
            <div className="flex items-center gap-4 mb-6">
               <span className="text-[10px] uppercase tracking-[0.4em] text-brand-sky font-bold">Inaugural CompSci Game Jam</span>
               <div className="h-[1px] w-12 bg-white/10" />
            </div>
            <h1 className="text-6xl font-serif italic font-bold tracking-tight mb-10 text-white leading-tight">
               Best <span className="text-brand-sky">Friends!</span> <br />
               The Tower Climb
            </h1>
            
            {/* Huge Play CTA */}
            <div className="relative group rounded-2xl overflow-hidden border border-white/10 bg-brand-card aspect-video flex flex-col items-center justify-center shadow-2xl overflow-hidden">
               <img 
                src="/src/assets/images/bestfriends_game_scene_1779108701086.png" 
                alt="Game Background" 
                className="absolute inset-0 w-full h-full object-cover opacity-20 blur-sm scale-110 group-hover:scale-100 transition-all duration-1000"
              />
              <div className="z-10 text-center p-12">
                <h2 className="text-4xl font-serif italic text-white mb-8">Ready to escape?</h2>
                <a 
                  href="#" 
                  target="_blank" 
                  rel="noopener noreferrer"
                  className="inline-flex items-center justify-center gap-4 bg-white text-black px-12 py-6 rounded-2xl text-lg font-bold uppercase tracking-[0.2em] hover:bg-brand-sky hover:text-white transition-all shadow-2xl active:scale-95 group/btn"
                >
                  PLAY HTML5 VERSION
                  <ExternalLink className="w-6 h-6 group-hover/btn:translate-x-1 group-hover/btn:-translate-y-1 transition-transform" />
                </a>
              </div>
              <div className="absolute inset-0 pointer-events-none bg-gradient-to-t from-brand-bg/80 via-transparent to-transparent" />
            </div>
          </motion.div>

          <section>
             <h3 className="text-xs uppercase tracking-[0.3em] text-white/40 mb-8 font-bold">Technical Specifications</h3>
             <div className="grid grid-cols-2 sm:grid-cols-4 gap-4">
                {[
                   { label: 'Engine', value: 'Unity 2026' },
                   { label: 'Rendering', value: '2D Pixel' },
                   { label: 'Target', value: 'WebGL' },
                   { label: 'Input', value: 'Dual Key' }
                ].map((spec) => (
                   <div key={spec.label} className="p-6 rounded-xl bg-white/[0.02] border border-white/5 hover:border-white/10 transition-colors">
                      <p className="text-[9px] uppercase tracking-[0.2em] text-slate-500 font-bold mb-3">{spec.label}</p>
                      <p className="text-sm font-serif italic font-bold text-white">{spec.value}</p>
                   </div>
                ))}
             </div>
          </section>
        </div>

        {/* Sidebar */}
        <aside className="space-y-12">
          {/* Support Local Devs */}
          <div className="p-10 rounded-2xl bg-brand-card border border-white/5 bg-gradient-to-br from-brand-card to-brand-bg">
            <h3 className="text-xs uppercase tracking-[0.3em] text-white/40 mb-6 font-bold">Project Details</h3>
            <div className="space-y-4">
               <div>
                  <p className="text-[10px] text-slate-500 uppercase tracking-widest mb-1 italic font-serif">Original Platform</p>
                  <p className="text-sm text-white">Browser / WebGL</p>
               </div>
               <div>
                  <p className="text-[10px] text-slate-500 uppercase tracking-widest mb-1 italic font-serif">Engine Requirements</p>
                  <p className="text-sm text-white">None (Safe in Browser)</p>
               </div>
            </div>
          </div>
        </aside>
      </div>
    </div>
  );
}
