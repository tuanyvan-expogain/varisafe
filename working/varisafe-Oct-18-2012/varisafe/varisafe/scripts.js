// JScript File



function ShowNextImage()
{


ItemImages = document.getElementsByName('rotatorImage_Img');
numItems = ItemImages.length;

var ShowNext = false;


for (var c = 0; c < numItems; c++)
    {
   
    if (ShowNext == false)
        {    
        
        if (ItemImages[c].parentNode.parentNode.className == 'show')
            {
           // alert("Found one");
           
            ItemImages[c].parentNode.parentNode.className = 'hide';
            ShowNext = true;       
            
            // check to see if this is the last item in the loop, if so make the first one show
            if ((c + 1) == numItems)
                {
                ItemImages[0].parentNode.parentNode.className = 'show';
                }
            
            } // end if class == 'SHOW'
        
        }
        else
        {   //alert(ShowNext);
           
            ItemImages[c].parentNode.parentNode.className = 'show';
            ShowNext = false;  
        }
    } // end for


}




 function showImg(filename)
{

stopTimer();

ItemImages = document.getElementsByName('rotatorImage_Img');
numItems = ItemImages.length;


for (var c = 0; c < numItems; c++)
    {
   
  
       
       
       //alert(filename);
       //alert(ItemImages[c].src);
       
       if (ItemImages[c].src.indexOf(filename) != -1)
            {
            // show this image
         //  alert("foundone");
           
            ItemImages[c].parentNode.parentNode.className = 'show';
                    
         
        
        }
        else {
        
        ItemImages[c].parentNode.parentNode.className = 'hide';
        }
       
    } // end for


}

function showMLS() 

{

mls = document.getElementById('txtMLS');



strUrl = 'http://www.realtor.ca/PropertyResults.aspx?Mode=5&id=' + mls.value;

window.open (strUrl, "mywindow","menubar=1,resizable=1,width=600,height=600"); 

}


function showBigImg(filename)
{
url = 'ZoomImg.aspx?img=' + filename
window.open(url, 'welcome', 'width=600,height=500,menubar=no,status=no,location=no,toolbar=no,scrollbars=no');
}