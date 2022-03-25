import React from 'react'
import './CoinsListPage.css'

class CoinsListPage extends React.Component {

    render() {
        console.log(this.props);

        const coinListSection = 
            <div className='coinListSection'>

                { this.renderSearchBar() }

                { this.renderSearchResultsSection() }

            </div>

        return coinListSection;
    }

    renderSearchBar() {

        const textbox = 
            <input type='text' className='coinSearchInput' />;
        
        return textbox;
    }

    renderSearchResultsSection() {

        const section = 
            <div className='searchResults'>
                <p>This is where dem damn search results are printed !</p>
            </div>

        return section;
    }
}


export default CoinsListPage;