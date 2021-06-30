import './App.css';
import '../../assets/Css/header.css';
import '../../assets/Css/footer.css';
import imghosp from '../../assets/img/medico1.png'
import { Link } from 'react-router-dom';



function App() {
  return (
      <div>
         <div className = "head">
        < Link to='https://cdn.jsdelivr.net/npm/boxicons@2.0.5/css/boxicons.min.css' rel='stylesheet'/> 
        <title>SP MEDICAL GROUP</title>
         </div>

         <Link to="#" className="scrolltop" id="scroll-top"/>
            <i className='bx bx-chevron-up scrolltop__icon'></i>
       

        <header className="l-header" id="header">
            <nav className="nav bd-container">
                < Link to="#" className="nav__logo">SP MEDICAL GROUP/</Link>

                <div className="nav__menu" id="nav-menu">
                    <ul className="nav__list">
                         <li className="nav__item"><Link to="#home" className="nav__link active-link">Início</Link></li>
                        <li className="nav__item"><Link to= 'https://www.google.com.br/maps/place/SP+Medical+Group/@-34.6194312,-58.51194,17z/data=!3m1!4b1!4m5!3m4!1s0x95bcc82ca6ea8077:0x4584245b3e799434!8m2!3d-34.619416!4d-58.509721' className="nav__link">Localização</Link></li>
                        <li className="nav__item"><Link to="#services" className="nav__link">Consultas</Link></li>
                        <li className="nav__item"><Link to="/Login" className="nav__link">Login</Link></li> 

                    </ul>
                </div>

                <div className="nav__toggle" id="nav-toggle">
                    <i className='bx bx-menu'></i>
                </div>
            </nav>
        </header>

        <main className="l-main"></main>

        <div className="home" id="home">
                <div className="home__container bd-container bd-grid">
                    <div className="home__data">
                        <h1 className="home__title">SP MEDICAL GROUP</h1>
                         < Link to="/Login" className="button">Login</Link> 
                    </div>
    
                    <img src={imghosp} className="home__img" alt = "imagem_hosp" />
                </div>
            </div>

            <section className="contact section bd-container" id="contact">
                <div className="contact__container bd-grid">
                    <div className="contact__data">
                        <span className="section-subtitle contact__initial">Fale Conosco</span>
                        <h2 className="section-title contact__initial">Entre em Contato</h2>
                        <p className="contact__description">Hospital é sempre hospital: não é lugar de alegrias, também não é de tristezas, mas de esperança.</p>
                    </div>

                    <div className="contact__button">
                         <Link to="#" className="button">Contato</Link>
                    </div>
                </div>
            </section>

            <footer className="footer section bd-container">
            <div className="footer__container bd-grid">
                <div className="footer__content">
                    <Link to="#" className="footer__logo">SP MEDICAL GROUP</Link>
                    <span className="footer__description">Hospital</span>
                    <div>
                         <Link to="#" className="footer__social"><i className='bx bxl-facebook'></i></Link>
                        <Link to="#" className="footer__social"><i className='bx bxl-instagram'></i></Link>
                      
                    </div>
                </div>

                <div className="footer__content">
                    <h3 className="footer__title">Serviços</h3>
                    <ul>
                        <li><Link to="#" className="footer__link">Dermatologia</Link></li>
                        <li><Link to="#" className="footer__link">Pediatria</Link></li>
                        <li><Link to="#" className="footer__link">Nuticionista</Link></li>
                        <li><Link to="#" className="footer__link">Psicologo</Link></li> 
                    </ul>
                </div>

                <div className="footer__content">
                    <h3 className="footer__title">Informação</h3>
                    <ul>
                        <li><Link to="#" className="footer__link">Contato (11) 4002-8922 </Link></li>
                       
                    </ul>
                </div>

                <div className="footer__content">
                    <h3 className="footer__title">Endereço</h3>
                    <ul>
                        <li>R. wilabix, 144</li>
                        <li>Embasbacado, São Paulo - SP</li>
                        <li> 07420-666</li>
                    </ul>
                </div>
            </div>

            <p className="footer__copy">&#169; 2021 Yuri and Guilherme. All right reserved</p>
        </footer>
  

      
       

 </div>//final-------------------------------------------
      

  )
}

export default App;
