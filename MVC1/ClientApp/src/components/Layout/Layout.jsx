import React from "react"
import Header from "./Header"
import Footer from "./Footer"

function Layout({children}) {
  
    return (
        
      <div className="container">
        <Header />
        <main role="main" className="pb-3">{children}</main>
        <Footer />
        </div>
    )
  }

export default Layout;